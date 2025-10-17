using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class InspectionType:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
