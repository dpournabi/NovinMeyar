using NovinMeyar.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// لیست سریال های گواهینامه ها
    /// </summary>
    public class SerialResource : BaseEntity
    {
        public SerialResource()
        {
            this.ElevatorInformations = new HashSet<ElevatorInformation>();
        }

        [Column(TypeName = "nvarchar(50)")]
        public string CertificateSerial { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string HologramNo { get; set; }
        public DateTime CreateDate { get; set; }
        public Branch Branch { get; set; }
        public IEnumerable<ElevatorInformation> ElevatorInformations { get; set; }
    }
}
