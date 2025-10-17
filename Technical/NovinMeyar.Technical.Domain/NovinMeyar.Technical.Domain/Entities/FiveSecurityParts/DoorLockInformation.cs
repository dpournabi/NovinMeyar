using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities.FiveSecurityParts
{
    /// <summary>
    /// اطلاعات قفل مکانیکی درب
    /// </summary>
    public class DoorLockInformation : BaseEntity
    {
        public ObjectDetail LockType { get; set; }//نام سازنده
        public long LockTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SerialNo { get; set; }

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
