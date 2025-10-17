using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع جنس کف
    /// </summary>
    public class BedMaterialType:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
