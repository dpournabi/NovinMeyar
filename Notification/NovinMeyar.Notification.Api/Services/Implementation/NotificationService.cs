using Microsoft.Extensions.Configuration;
using NovinMeyar.Common;
using NovinMeyar.Notification.Api.Providers;
using Serilog;

namespace NovinMeyar.Notification.Api.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public NotificationService(IConfiguration configuration, ILogger logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public INotificationProvider GetNotificationProvider(NotificationType? notificationType = NotificationType.Email)
        {
            var appSettings = configuration.Get<AppSettings>();

            INotificationProvider defaultProvider = 
                notificationType == NotificationType.Sms ? new SmsProvider() 
                                                         : new EmailProvider(appSettings.EmailSettings, logger);
            return defaultProvider;
        }
    }
}
