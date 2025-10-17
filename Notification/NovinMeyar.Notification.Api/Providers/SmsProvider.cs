using System;
using System.Threading.Tasks;
using NovinMeyar.Notification.Api.Models;
using NovinMeyar.Common;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace NovinMeyar.Notification.Api.Providers
{
    class SmsProvider : INotificationProvider
    {
        public async Task<ResponseModel> SendMessageAsync(NotificationModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> SendVerificationCodeAsync(VerifyCode model)
        {
            return await SmsIrProvider.GetInstance().PostAsync(JsonSerializer.Serialize(new InternalVerifyModel
            {
                Mobile = model.Mobile,
                TemplateId = "432420",
                Parameters = new System.Collections.Generic.List<Parameter>
                    {
                        new Parameter { Name= "Code", Value=model.Code }
                    }
            }), Constantants.VerifyCode);
        }

        public async Task<ResponseModel> SendCustomMessageAsync(string message, string mobile)
        {
            return await SmsIrProvider.GetInstance().PostAsync(JsonSerializer.Serialize(new CustomMessageModel
            {
                MessageText = message,
                Mobiles = new System.Collections.Generic.List<string> { mobile.PadLeft(11, '0') }
            }), Constantants.SendMessage);
        }
    }
}
