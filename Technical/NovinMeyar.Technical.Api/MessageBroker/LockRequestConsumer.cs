using MassTransit;
using Newtonsoft.Json;
using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.MessageBroker
{
    public class LockRequestConsumer : IConsumer<LockRequestBroker>
    {
        private readonly IFastRegisrationRequestService fastRegisrationRequestService;
        public LockRequestConsumer(IFastRegisrationRequestService fastRegisrationRequestService)
        {
            this.fastRegisrationRequestService = fastRegisrationRequestService;
        }
        public async Task Consume(ConsumeContext<LockRequestBroker> context)
        {
            try
            {
                Log.Information($"Starting lock request for ElevatorInformationId:{context.Message.ElevatorInformationId} in consumer!");
                var searchResult = await fastRegisrationRequestService.SearchAsync(new FastRegistrationSearch { Id = context.Message.ElevatorInformationId.ToString() }, -1, true, null, null);
                var obj = searchResult.ResponseList.FirstOrDefault();
                var response = new ResponseModel { Succeed = false, Message = "رکورد مورد نظر یافت نشد" };
                if (obj == null)
                {
                    await context.RespondAsync(response);
                    return;
                }
                response = await fastRegisrationRequestService.LockRequest(context.Message.ElevatorInformationId, "System");
                Log.Information($"Locking request {context.Message.ElevatorInformationId} was successfully!");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(fastRegisrationRequestService)} --> {nameof(Consume)}");
            }

        }
    }
}
