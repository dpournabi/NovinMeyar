using System;
using Serilog;
using MassTransit;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NovinMeyar.Cartabl.Api.Services;
using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Cartabl.Api.MessageBroker
{
    public class RequestConsumer : IConsumer<RequestRegistrationBroker>
    {
        private readonly IRequestService requestService;
        public RequestConsumer(IRequestService requestService)
        {
            this.requestService = requestService;
        }
        public async Task Consume(ConsumeContext<RequestRegistrationBroker> context)
        {
            try
            {
                Log.Information("New request recieved!");
                var response = await requestService.RegisterNewRequest(context.Message);
                Log.Information($"Register a new request at {DateTime.Now}. Recieved model: { context.Message }");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(RequestConsumer)} --> {nameof(Consume)} --> Error deatail");
            }
            
        }
    }
}