using MassTransit;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Notification.Api.Providers;
using NovinMeyar.Notification.Api.Services;
using Serilog;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace NovinMeyar.Notification.Api.MessageBroker
{
    public class CustomMessageConsumer : IConsumer<CustomMessageBroker>
    {
        private readonly INotificationService notificationService;
        private readonly INotificationProvider notificationProvider;
        public CustomMessageConsumer(INotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.notificationProvider = notificationService.GetNotificationProvider(NotificationType.Sms);
        }

        public async Task Consume(ConsumeContext<CustomMessageBroker> context)
        {
            try
            {
                Log.Information($"Start sending message for {context.Message.MobileNumber}");
                var response = await notificationProvider.SendCustomMessageAsync(context.Message.TextMessage, context.Message.MobileNumber);
                Log.Information($"End sending message at {DateTime.Now}. Recieved model: {JsonSerializer.Serialize(context.Message)}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(VerificationCodeConsumer)} --> {nameof(Consume)} --> Error deatail");
            }
        }
    }
}
