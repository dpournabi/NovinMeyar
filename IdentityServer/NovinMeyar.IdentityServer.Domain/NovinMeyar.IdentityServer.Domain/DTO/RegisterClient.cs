using NovinMeyar.Helpers.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class RegisterClient
    {
        [Required(ErrorMessage ="نام کاربری الزامی است")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی است")]
        [MinLength(8, ErrorMessage ="حداقل طول کلمه عبور 8 رقم می باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تایید کلمه عبور الزامی است")]
        [MinLength(8, ErrorMessage = "حداقل طول تایید کلمه عبور 8 رقم می باشد")]
        [Compare("Password", ErrorMessage ="کلمه عبور و تایید آن یکسان نیستند")]
        public string ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "ارسال نام شرکت الزامی است")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Company national code
        /// </summary>
        [Required(ErrorMessage = "ارسال شناسه ملی شرکت الزامی است")]
        public string NationalCode { get; set; }

        /// <summary>
        /// Company register number
        /// </summary>
        [Required(ErrorMessage = "ارسال شماره ثبت شرکت الزامی است")]
        public string RegisterNo { get; set; }

        [Required(ErrorMessage = "انتخاب محل ثبت شرکت الزامی است")]
        public long ProvinceId { get; set; }
    }
}
