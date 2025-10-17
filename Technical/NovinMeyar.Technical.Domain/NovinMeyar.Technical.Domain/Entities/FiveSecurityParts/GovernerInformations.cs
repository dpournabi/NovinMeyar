using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities.FiveSecurityParts
{
    public class GovernerInformations : BaseEntity
    {
        public ObjectDetail GovernerType { get; set; }//نوع گاورنر
        public long GovernerTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SerialNo { get; set; }
        public float MaximumValidSpeed { get; set; }//سرعت درگیری
        public bool HasTwoWays { get; set; }//دوطرفه

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
