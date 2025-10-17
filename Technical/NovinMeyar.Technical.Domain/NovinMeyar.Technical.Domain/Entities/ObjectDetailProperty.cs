
using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class ObjectDetailProperty:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Value { get; set; }
        public long ObjectDetailId { get; set; }
        public ObjectDetail ObjectDetail { get; set; }
        public long PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
