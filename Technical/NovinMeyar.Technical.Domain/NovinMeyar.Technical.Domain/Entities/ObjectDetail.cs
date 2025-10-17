
using NovinMeyar.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class ObjectDetail : BaseEntity
    {
        public ObjectDetail()
        {
            this.ObjectDetailProperties = new HashSet<ObjectDetailProperty>();
            this.Childs = new List<ObjectDetail>();
        }

        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int Level { get; set; }//Node level
        public long? ParentId { get; set; }
        public long? ElevatorTypeId { get; set; }
        public ElevatorType ElevatorType { get; set; }
        public IEnumerable<ObjectDetailProperty> ObjectDetailProperties { get; set; }
        public IList<ObjectDetail> Childs { get; set; }
    }
}
