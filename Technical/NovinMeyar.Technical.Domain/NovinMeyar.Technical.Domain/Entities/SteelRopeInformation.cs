using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// جزییات طناب فولادی
    /// </summary>
    public class SteelRopeInformation : BaseEntity
    {
        public ObjectDetail RopeType { get; set; }//نوع طناب فولادی
        public long RopeTypeId { get; set; }
        public int RopeCount { get; set; }//تعداد طناب
        public float CableDiameter { get; set; }//قطر طناب فولادی
        public float SuspendedLength { get; set; }//طول معلق طناب فولادی

        //One to one relationship
        public long? ElevatorInformationId { get; set; }
        public virtual ElevatorInformation ElevatorInformation { get; set; }

    }
}
