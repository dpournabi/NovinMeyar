using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.FileManagment.Domain
{
    public class LargeFileStream : IFileStream
    {
        [Required(ErrorMessage = "انتخاب یک فایل جهت آپلود الزامی است")]
        [DataType(DataType.Upload)]
        [MaxFileSize(20 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".rar", ".zip" })]
        public IFormFile Photo { get; set; }
        public string Tag { get; set; }//SystemName-EntityName-PrimaryKey-Guid
        public string UserCreatorName { get; set; }
    }
}
