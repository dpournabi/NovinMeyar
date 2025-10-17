using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class VerifyCode
    {
        [Required(ErrorMessage ="ارسال نام کاربری اجباری می باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ارسال کد پیامک شده اجباری می باشد")]
        public string PlainCode { get; set; }
    }
}
