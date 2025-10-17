
using NovinMeyar.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class Property : BaseEntity
    {
        public Property()
        {
            this.ObjectDetailProperties = new HashSet<ObjectDetailProperty>();
        }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }
        public IEnumerable<ObjectDetailProperty> ObjectDetailProperties { get; set; }
    }
}
