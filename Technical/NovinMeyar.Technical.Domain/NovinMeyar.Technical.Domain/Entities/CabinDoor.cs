using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class CabinDoor:BaseEntity
    {
        public LocationType LocationType { get; set; }//موقعیت درب
        public long LocationTypeId { get; set; }
        public int DoorWidth { get; set; }//عرض درب
        public DoorType DoorType { get; set; }//نوع درب
        public long DoorTypeId { get; set; }
        public int EnteringDepth { get; set; }//عمق آستانه
        public int CabinDoorDepth { get; set; }//عمق درب کابین
        public decimal DoorHeight { get; set; }//ارتفاع
        public int OpeningSide { get; set; }//جهت باز شدن درب طبقات Right,Left,Central

        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
