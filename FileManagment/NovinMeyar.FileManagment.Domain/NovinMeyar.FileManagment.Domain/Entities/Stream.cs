using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.FileManagment.Domain.Entities
{
    /// <summary>
    /// محل نگهداری کلیه فایل ها
    /// </summary>
    public class Stream : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FileName { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string FileExtention { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Tag { get; set; }//SystemName-EntityName-PrimaryKey-Guid
        public byte[] Content { get; set; }
        public bool IsValid { get; set; }
    }
}
