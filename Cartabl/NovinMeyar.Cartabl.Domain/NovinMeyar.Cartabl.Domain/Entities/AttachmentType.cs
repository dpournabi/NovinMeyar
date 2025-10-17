using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Cartabl.Domain.Entities
{
    /// <summary>
    /// نوع پیوست
    /// </summary>
    public class AttachmentType:BaseEntity
    {
        public string Extention { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
