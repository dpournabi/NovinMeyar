using System;
using Serilog;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using NovinMeyar.Notification.Api.Models;
using System.Text;
using NovinMeyar.Common;

namespace NovinMeyar.Notification.Api.Providers
{
    class EmailProvider : INotificationProvider
    {
        private readonly EmailSettings emailSettings;
        private readonly ILogger logger;

        #region Ctor
        public EmailProvider(EmailSettings emailSettings, ILogger logger)
        {
            this.emailSettings = emailSettings;
            this.logger = logger;
        }

        #endregion

        public async Task<ResponseModel> SendMessageAsync(NotificationModel model) => await SendAsyncMessage(model);
        public Task<ResponseModel> SendVerificationCodeAsync(VerifyCode model)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseModel> SendCustomMessageAsync(string message, string mobile)
        {
            throw new NotImplementedException();
        }
        #region Private Methods...
        private Task<ResponseModel> SendAsyncMessage(NotificationModel model)
        {
            var response = new ResponseModel { Succeed = false };
            var sb = new StringBuilder();

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(emailSettings.EmailFromAddress);
                mail.To.Add(emailSettings.EmailToAddress);
                mail.Subject = model.Subject;

                sb.Append("<p style='font-family:tahoma; direction: rtl;'>");
                if (!string.IsNullOrWhiteSpace(model.FullName))
                    sb.Append($"نام: <b> {model.FullName} </b> </br></br>");

                if (!string.IsNullOrWhiteSpace(model.CellPhone))
                    sb.Append($"همراه: <b> {model.CellPhone} </b> </br></br>");

                sb.Append($"متن پیام: {model.Message} </p> </br></br>");

                mail.Body = sb.ToString();
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                var smtp = new SmtpClient(emailSettings.SmtpAddress, emailSettings.PortNumber);
                smtp.SendCompleted += (sender, e) =>
                {
                    smtp.Dispose();
                    mail.Dispose();
                };
                smtp.Credentials = new NetworkCredential(emailSettings.EmailFromAddress, emailSettings.Password);
                smtp.EnableSsl = emailSettings.EnableSSL;
                smtp.SendAsync(mail, null);

                response.Succeed = true;
                response.HttpStatusCode = HttpStatusCode.OK;
                response.Message = "ارسال درخواست با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error occured in email sending message provider!");
                response.Message = ex.Message;
            }

            return Task.FromResult(response);
        }
        #endregion
    }
}
