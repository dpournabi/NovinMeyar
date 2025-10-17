
using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع کاربری آسانسور: مسافربر-باربر-خودروبر-تخت بر
    /// </summary>
    public class UseType:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
