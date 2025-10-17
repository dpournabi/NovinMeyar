using Microsoft.EntityFrameworkCore;
using NovinMeyar.Cartabl.Api.Enums;
using NovinMeyar.Cartabl.DataLayer;
using NovinMeyar.Cartabl.Domain.Entities;
using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;
using Serilog;
using System;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.Services
{
    public class RequestService : IRequestService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        public RequestService(DataContext dataContext,
            ILogger logger)
        {
            this.dataContext = dataContext;
            this.logger = logger;
        }

        public async Task<ResponseModel> RegisterNewRequest(RequestRegistrationBroker model)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (await dataContext.Requests
                    .AnyAsync(x => (x.BranchId == model.BranchId && x.RequestTitle == model.RequestTitle) ||
                                   (model.RequestId != null && x.Id == model.RequestId)))
                {
                    response.Succeed = true;
                    response.Message = "درخواست در سیستم قبلا ثبت شده است";
                    response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    return response;
                }
                var request = new Request
                {
                    BranchId = model.BranchId,
                    RequestTitle = model.RequestTitle,
                    RequestTypeId = model.RequestTypeId.Value,
                    Url = model.Url,
                    Deleted = false,
                    IsSeen = false,
                    IsActive = true,
                    IsArchive = false,
                    CreateDate = DateTime.Now,
                    UserCreatorName = model.UserName,
                    SystemName = model.SystemName,
                    States = -1,
                    LastState = -1,
                    BranchName = model.BranchName,
                    CustomerFullName = model.CustomerFullName,
                    InstallationCompanyName = model.InstallationCompanyName,
                    InstallationCompanyId = model.InstallationCompanyId,
                    SourceTableKey = model.SourceTableKey
                };

                await dataContext.Requests.AddAsync(request);
                await dataContext.SaveChangesAsync();

                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} - {nameof(RequestService)} --> {nameof(RegisterNewRequest)} --> Error deatail: {ex.Message}");
                response.Message = "در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ResponseModel> UpdateRequest(UpdateRequestBroker model)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var request = await dataContext.Requests.FirstAsync(x => x.SourceTableKey == model.SourceTableKey);
                request.RequestTitle = model.DocumentNumber;
                request.BranchName = model.BranchName;
                await dataContext.SaveChangesAsync();

                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} - {nameof(RequestService)} --> {nameof(RegisterNewRequest)} --> Error deatail: {ex.Message}");
                response.Message = "در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
