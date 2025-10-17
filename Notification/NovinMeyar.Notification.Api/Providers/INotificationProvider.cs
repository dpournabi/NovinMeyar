using NovinMeyar.Common;
using NovinMeyar.Notification.Api.Models;
using System.Threading.Tasks;

namespace NovinMeyar.Notification.Api.Providers
{
    public interface INotificationProvider
    {
        Task<ResponseModel> SendMessageAsync(NotificationModel model);
        Task<ResponseModel> SendVerificationCodeAsync(VerifyCode model);
        Task<ResponseModel> SendCustomMessageAsync(string message, string mobile);
    }
}
