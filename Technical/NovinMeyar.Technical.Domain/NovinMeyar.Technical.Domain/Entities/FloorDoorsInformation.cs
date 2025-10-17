using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// درب طبقات
    /// </summary>
    public class FloorDoorsInformation : BaseEntity
    {
        public LocationType LocationType { get; set; }//موقعیت(جلو,عقب,چپ,راست)
        public long LocationTypeId { get; set; }
        public DoorType DoorType { get; set; }//نوع درب_IsCabin = false
        public long DoorTypeId { get; set; }
        public int DoorWidth { get; set; }//عرض درب
        public int ThresholdDepth { get; set; }//عمق آستانه
        public int DoorTickness { get; set; }//ضخامت درب
        public int OpeningSide { get; set; }//جهت باز شدن درب طبقات Right,Left,Central
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
