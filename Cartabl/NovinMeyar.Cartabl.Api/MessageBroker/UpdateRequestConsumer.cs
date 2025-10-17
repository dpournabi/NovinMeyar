using MassTransit;
using NovinMeyar.Cartabl.Api.Services;
using NovinMeyar.Common.MessageBrokers;
using Serilog;
using System;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.MessageBroker
{
    public class UpdateRequestConsumer : IConsumer<UpdateRequestBroker>
    {
        private readonly IRequestService requestService;
        public UpdateRequestConsumer(IRequestService requestService)
        {
            this.requestService = requestService;
        }
        public async Task Consume(ConsumeContext<UpdateRequestBroker> context)
        {
            try
            {
                Log.Information("New request recieved!");
                var response = await requestService.UpdateRequest(context.Message);
                Log.Information($"Register a new request at {DateTime.Now}. Recieved model: {context.Message}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(RequestConsumer)} --> {nameof(Consume)} --> Error deatail");
            }

        }
    }
}