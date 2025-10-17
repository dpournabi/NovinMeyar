using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.FileManagment.Domain
{
    public class NormalFileStream : IFileStream
    {
        [Required(ErrorMessage = "انتخاب یک فایل جهت آپلود الزامی است")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".pdf", "*.jpeg" })]
        public IFormFile Photo { get; set; }
        public string Tag { get; set; }//SystemName-EntityName-PrimaryKey-Guid
        public string UserCreatorName { get; set; }
    }
}
