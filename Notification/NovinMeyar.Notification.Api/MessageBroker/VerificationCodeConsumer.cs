using System;
using Serilog;
using MassTransit;
using System.Text.Json;
using System.Threading.Tasks;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Notification.Api.Services;
using NovinMeyar.Notification.Api.Providers;

namespace NovinMeyar.Notification.Api.MessageBroker
{
    public class VerificationCodeConsumer : IConsumer<VerificationCodeBroker>
    {
        private readonly INotificationService notificationService;
        private readonly INotificationProvider notificationProvider;
        public VerificationCodeConsumer(INotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.notificationProvider = notificationService.GetNotificationProvider(NotificationType.Sms);
        }

        public async Task Consume(ConsumeContext<VerificationCodeBroker> context)
        {
            try
            {
                Log.Information($"Start sending message for {context.Message.Mobile}");
                var response = await notificationProvider.SendVerificationCodeAsync(new Models.VerifyCode
                {
                    Code = context.Message.Code,
                    Mobile = context.Message.Mobile
                });
                
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
