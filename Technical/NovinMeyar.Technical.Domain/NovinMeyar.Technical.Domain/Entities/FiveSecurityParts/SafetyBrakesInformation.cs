using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities.FiveSecurityParts
{
    /// <summary>
    /// اطلاعات ترمز ایمنی
    /// </summary>
    public class SafetyBrakesInformation : BaseEntity
    {
        public ObjectDetail SafetyBrakesType { get; set; }//نام سازنده
        public long SafetyBrakesTypeId { get; set; }

        public BrakeType BrakeType { get; set; }//نوع ترمز ایمنی
        public long BrakeTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SerialNo { get; set; }
        public LocationType LocationType { get; set; }//موقعیت نصب
        public long LocationTypeId { get; set; }
        public decimal CapacityWeight { get; set; }//ظرفیت(P+Q)
        public bool TangleSide { get; set; }//جهت درگیری
        public float MaximumSpeed { get; set; }//حداکثر سرعت مجاز

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
