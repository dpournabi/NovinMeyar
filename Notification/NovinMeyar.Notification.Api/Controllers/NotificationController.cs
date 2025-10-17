using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Notification.Api.Models;
using NovinMeyar.Notification.Api.Services;
using System.Threading.Tasks;

namespace NovinMeyar.Notification.Api.Controllers
{
    [EnableCors(Constants.CorsName)]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class NotificationController : BaseController
    {
        private readonly INotificationService notificationService;
        
        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        /// <summary>
        /// ارسال انتقادات پیشنهادات از طریق
        /// وب سایت توسط کاربر ناشناس
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailNotificationAsync(NotificationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var emailProvider = notificationService.GetNotificationProvider(NotificationType.Email);
            return Ok(await emailProvider.SendMessageAsync(model));
        }

        //[HttpPost]
        //[Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.BranchManager)]
        //public async Task<IActionResult> SendSmsAsync(NotificationModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(model);
        //    }

        //    var smsProvider = notificationService.GetNotificationProvider(NotificationType.Sms);
        //    return Ok(await smsProvider.SendMessageAsync(model));
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> SendVerificationCodeAsync(VerifyCode model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(model);
        //    }

        //    var smsProvider = notificationService.GetNotificationProvider(NotificationType.Sms);
        //    return Ok(await smsProvider.SendVerificationCodeAsync(model));
        //}
    }
}
