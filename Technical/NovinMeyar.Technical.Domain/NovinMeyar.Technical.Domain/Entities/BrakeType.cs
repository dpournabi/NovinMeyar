using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع ترمز
    /// </summary>
    public class BrakeType : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
    }
}
