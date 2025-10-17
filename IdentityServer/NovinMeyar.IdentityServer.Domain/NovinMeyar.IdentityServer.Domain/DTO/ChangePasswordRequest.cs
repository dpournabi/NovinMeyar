using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage ="ارسال کلمه عبور فعلی اجباری می باشد")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "ارسال کلمه عبور جدید اجباری می باشد")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "ارسال تایید کلمه عبور اجباری می باشد")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "کلمه عبور و تایید آن یکسان نیستند")]
        public string ConfirmationPassword { get; set; }
    }
}
