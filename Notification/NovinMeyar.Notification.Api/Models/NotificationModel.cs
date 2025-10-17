using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Notification.Api.Models
{
    public class NotificationModel
    {
        [Required(ErrorMessage ="عنوان درخواست الزامی می باشد")]
        [MaxLength(100, ErrorMessage = "عنوان بیش از 100 کاراکتر می باشد")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "متن درخواست الزامی می باشد")]
        [MaxLength(500, ErrorMessage = "متن پیغام بیش از حد مجاز 500 کاراکتر می باشد")]
        public string Message { get; set; }

        [MaxLength(30, ErrorMessage = "نام و نام خانوادگی بیش از 30 کاراکتر می باشد")]
        public string FullName { get; set; }

        [MaxLength(11, ErrorMessage ="طول شماره موبایل صحیح نمی باشد")]
        public string CellPhone { get; set; }
    }
}
