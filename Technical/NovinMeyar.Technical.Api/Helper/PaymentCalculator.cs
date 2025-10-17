using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NovinMeyar.Common;
using NovinMeyar.Technical.Api.Models;
using NovinMeyar.Technical.DataLayer;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Helper
{
    public interface IPaymentCalculator
    {
        Task<ResponseModel> CalculateAsync(long elevatorInformationId);
    }
    public class PaymentCalculator : IPaymentCalculator
    {
        private readonly DataContext dataContext;
        private readonly IConfiguration configuration;
        public PaymentCalculator(DataContext dataContext, IConfiguration configuration)
        {
            this.dataContext = dataContext;
            this.configuration = configuration;
        }

        public async Task<ResponseModel> CalculateAsync(long elevatorInformationId)
        {
            var appSettings = configuration.Get<AppSettings>();
            var response = new ResponseModel { Succeed = false };
            try
            {
                var res = new PaymentCalculatorResponse();
                var elevatorInformation = await dataContext.ElevatorInformations.AsNoTracking().FirstAsync(x=> x.Id == elevatorInformationId);
                Log.Information("<< elevatorInformation >> " + JsonConvert.SerializeObject(elevatorInformation));
                var elevatorInspection = await dataContext.ElevatorInspections.Where(x => x.ElevatorInformationId == elevatorInformationId && !x.Deleted && x.PaymentId!=null).OrderByDescending(x => x.CreateDate).FirstOrDefaultAsync();
                Log.Information("<< elevatorInspection >> " + JsonConvert.SerializeObject(elevatorInspection));
                int row = ((elevatorInspection == null) ? 0 : elevatorInspection.Row) + 1;
                Log.Information("<< row >> " + row);
                //++row;
                int step = row <= 3 ? row : 3;
                Log.Information("<< step >> " + step);

                var tariff = await dataContext.InspectionTariffs.AsNoTracking().FirstAsync(x => x.Deleted == false && x.InspectionTypeId == elevatorInformation.InspectionTypeId &&
                                                                                 x.Step == step && !x.Deleted && x.EndDate == null);
                Log.Information("<< tariff >> " + JsonConvert.SerializeObject(tariff));
                if (elevatorInformation.StopCount == null)
                {
                    response.Message = "تعداد توقف نمی تواند تهی باشد";
                    return response;
                } 

                res.TariffValue = tariff.Amount;
                res.AddtionalStopCount = elevatorInformation.StopCount < 5 ? 0 : elevatorInformation.StopCount.Value - 5;
                res.AdditionalPayPerStepValue = tariff.AdditionalPayPerStopCount;
                res.TravelExpenseValue = LocalConstants.TravelExpenses;
                decimal tmpTotal = res.TariffValue + (res.AdditionalPayPerStepValue * res.AddtionalStopCount) + LocalConstants.TravelExpenses;
                res.TaxValue = (tmpTotal * LocalConstants.Tax) / 100;
                res.TotalPaymenyValue = tmpTotal + res.TaxValue;
                res.Step = step;
                
                if (appSettings.TestMode)
                {
                    res.TotalPaymenyValue = 1000;
                    res.TaxValue = 0;
                    res.AdditionalPayPerStepValue = 0;
                    res.TravelExpenseValue = 0;
                    res.TariffValue = 0;
                    res.AddtionalStopCount = 0;
                }
                response.Data = res;
                response.Succeed = true;

                Log.Information("<< response >> " + JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                Log.Error("<< Error raised on caculation price value >> " + JsonConvert.SerializeObject(ex));
                response.Message = ex.Message.ToString();
            }

            return response;
        }
    }
}
