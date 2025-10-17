using System;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using NovinMeyar.Technical.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.DTO;
using NovinMeyar.Technical.Domain.Views;
using NovinMeyar.Common;
using NovinMeyar.Technical.Api.Helper;
using NovinMeyar.Technical.Api.Models;
using MassTransit;
using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Technical.Api.Services.ver_1._0.Implementation
{
    public class ElevatorInspectionService : IElevatorInspectionService
    {
        private readonly DataContext dataContext;
        private readonly IConfiguration configuration;
        private readonly IPaymentCalculator paymentCalculator;
        private readonly IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient;
        public ElevatorInspectionService(DataContext dataContext,
            IConfiguration configuration,
            IPaymentCalculator paymentCalculator,
            IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient)
        {
            this.dataContext = dataContext;
            this.configuration = configuration;
            this.paymentCalculator = paymentCalculator;
            this.messageBrokerClient = messageBrokerClient;
        }

        public async Task<ResponseModel<ElevatorInspectionViewModel>> GetAsync(long elevatorInformationId)
        {
            var data = await (from ei in dataContext.ElevatorInspections
                              join einfo in dataContext.ElevatorInformations on ei.ElevatorInformationId equals einfo.Id
                              join insT in dataContext.InspectionTypes on einfo.InspectionTypeId equals insT.Id
                              where !ei.Deleted &&
                              ei.ElevatorInformationId == elevatorInformationId
                              orderby ei.Row
                              select new ElevatorInspectionViewModel
                              {
                                  Id = ei.Id,
                                  InspectionType = insT.Title,
                                  StopCount = einfo.StopCount.Value,
                                  Tag=ei.Tag,
                                  Row = ei.Row,
                                  Amount = ei.Amount,
                                  CreateDate = ei.CreateDate,
                                  InspectionDate=ei.InspectionDate,
                                  InspectionTime= ei.InspectionTime.HasValue ? ei.InspectionTime.Value.ToString("HH:mm") : null,
                                  PaymentId = ei.PaymentId,
                                  PaymentDate = ei.PaymentDate,
                                  ResponsibleCell = einfo.ResponsibleCell
                              })
                       .ToListAsync();

            return new ResponseModel<ElevatorInspectionViewModel>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<ResponseModel> FindAsync(long key)
        {
            var response = new ResponseModel { Succeed=true };
            response.Data = await dataContext.ElevatorInspections.FindAsync(key);
            return response;
        }
        public async Task<ResponseModel> FindAsync(Guid key)
        {
            var response = new ResponseModel { Succeed = true };
            response.Data = await dataContext.ElevatorInspections.FirstOrDefaultAsync(x=>x.Tag==key);
            return response;
        }

        public async Task<ResponseModel> UpdatePaymentStateAsync(long elevatorInspectionId, Guid? paymentId, DateTimeOffset? paymentDate)
        {
            var response = new ResponseModel { Succeed = false };
            var elevatorInspection = await dataContext.ElevatorInspections.FindAsync(elevatorInspectionId);
            elevatorInspection.PaymentId = paymentId;
            elevatorInspection.PaymentDate = paymentDate;
            await dataContext.SaveChangesAsync();

            response.Succeed = true;
            response.Message = "عملیات ثبت با موفقیت انجام شد";
            return response;
        }

        public async Task<ResponseModel> SaveAsync(ElevatorInspectionModel model, string userName)
        {
            var validation = OnValidateModel(model);
            if (!validation.Succeed)
                return validation;

            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var existsUnpay = await dataContext.ElevatorInspections.FirstOrDefaultAsync(x => x.ElevatorInformationId == model.ElevatorInformationId && !x.Deleted && x.PaymentId==null);
                if (existsUnpay!=null)
                {
                    response.Succeed = false;
                    response.Message = $"فاکتور مرتبه {existsUnpay.Row} پرداخت نشده است";
                    return response;
                }

                var paymentResponse = await paymentCalculator.CalculateAsync(model.ElevatorInformationId);
                if(!paymentResponse.Succeed)
                {
                    response.Message = paymentResponse.Message;
                    return response;
                }

                PaymentCalculatorResponse payment = (PaymentCalculatorResponse)paymentResponse.Data;

                var newEntity = new ElevatorInspection
                {
                    ElevatorInformationId = model.ElevatorInformationId,
                    Amount = payment.TotalPaymenyValue,
                    Row = payment.Step,
                    Tag = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    UserCreatorName = userName
                };
                await dataContext.ElevatorInspections.AddAsync(newEntity);
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات ثبت با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                response.ExteraInformation = model.Id.ToString();
                return response;

            }
            catch (Exception ex)
            {
                Log.Error($"{DateTime.Now} - {nameof(ElevatorInspectionService)} --> {nameof(SaveAsync)} --> Error deatail: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                response.Message = $"در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود. ErrorDetails: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;

        }
        public async Task<ResponseModel> NotifyAsync(NotifyModel notifyModel)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (string.IsNullOrEmpty(notifyModel.PhoneNumber))
                {
                    response.Message = "شماره ارسالی صحیح نمی باشد";
                    response.HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity;
                    return response;
                }

                var elevatorInspection = await dataContext.ElevatorInspections.FindAsync(notifyModel.ElevatorInspectionId);
                if(elevatorInspection == null)
                {
                    response.Message = "شناسه ارسالی صحیح نیست";
                    response.HttpStatusCode=System.Net.HttpStatusCode.UnprocessableEntity;
                    return response;
                }
                string paymentLink = $"http://payment.nmaa.co.ir/Payment/PrePaymentView?key={elevatorInspection.Tag.ToString()}";
                string message = @$"کارفرمای محترم لطفا با استفاده از لینک زیر نسبت به پرداخت هزینه بازرسی خود اقدام نمایید: \n شرکت نوین معیار آزمای آپادانا \n {paymentLink}";
                await messageBrokerClient.GetResponse<ResponseModel>(new CustomMessageBroker
                {
                    MobileNumber = notifyModel.PhoneNumber.PadLeft(11, '0'),
                    TextMessage = message
                });

                response.Message = "ارسال لینک پرداخت با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(ElevatorInspectionService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> DeactiveAsync(long id, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (id <= 0)
                    return response;

                var obj = await dataContext.ElevatorInspections.FindAsync(id);

                if(obj.PaymentId!=null)
                {
                    response.Message = "شما مجاز به حذف رکورد پرداخت شده نیستید";
                    response.Succeed = false;
                    response.HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity;
                    return response;
                }

                obj.Deleted = true;
                obj.UserModifiedName = userName ?? "";
                obj.UserModifiedDate = DateTime.Now;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(ElevatorInspectionService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        private ResponseModel OnValidateModel(ElevatorInspectionModel model)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            if (model == null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                return response;
            }

            if (model.ElevatorInformationId <= 0)
            {
                response.Message = "ارسال شناسه اصلی اجباری می باشد";
                return response;
            }

            response.Succeed = true;
            response.HttpStatusCode = System.Net.HttpStatusCode.OK;

            return response;
        }
    }
}
