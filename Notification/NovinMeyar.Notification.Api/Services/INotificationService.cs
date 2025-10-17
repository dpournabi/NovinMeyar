using NovinMeyar.Notification.Api.Providers;

namespace NovinMeyar.Notification.Api.Services
{
    public interface INotificationService
    {
        INotificationProvider GetNotificationProvider(NotificationType? notificationType);
    }
}
