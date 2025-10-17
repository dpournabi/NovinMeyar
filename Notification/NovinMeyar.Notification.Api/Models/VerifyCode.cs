using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Notification.Api.Models
{
    public class VerifyCode
    {
        [Required(ErrorMessage ="ارسال شماره موبایل الزامی می باشد")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "ارسال شماره موبایل الزامی می باشد")]
        public string Code { get; set; }
    }
}
