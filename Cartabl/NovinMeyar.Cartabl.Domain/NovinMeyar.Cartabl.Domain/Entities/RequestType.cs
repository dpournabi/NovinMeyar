using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Cartabl.Domain.Entities
{
    /// <summary>
    /// نوع درخواست
    /// </summary>
    public class RequestType:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
