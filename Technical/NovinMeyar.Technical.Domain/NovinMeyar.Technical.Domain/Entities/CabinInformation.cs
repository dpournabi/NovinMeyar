using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// اطلاعات کابین
    /// </summary>
    public class CabinInformation : BaseEntity
    {
        public long ElevatorInformationId { get; set; }
        public int CarCapacityCount { get; set; }//ظرفیت تعدادی
        public float CarCapacityWeight { get; set; }//)نامی)ظرفیت وزنی
        public float CarWeight { get; set; }//جرم کابین
        public float MaximumAcceleration { get; set; }//حداکثر شتاب
        public float CabinDepth { get; set; }//عمق کابین
        public float CabinHeight { get; set; }//ارتفاع کابین
        public float CabinWidth { get; set; }//عرض کابین
        public float CabinTrayHeight { get; set; }//ارتفاع سینی کابین
        public float ApproximateCabinWeight { get; set; }//وزن تقریبی کابین_احتملا این فیلد بعدها حذف شود
        public bool HasLightSensor { get; set; }//حسگر نوری درب کابین
        public bool HasCarLockDoor { get; set; }//سیستم قفل مکانیکی درب کابین
        public float CalculatedCapacity { get; set; }//ظرفیت محاسبه شده
        public ShoesType ShoesType  { get; set; }//نوع کفشک راهنمای کابین
        public long ShoesTypeId { get; set; }
        public float VerticalShoesDistance { get; set; }//فاصله عمودی بین کفشک های کابین
        public InstallRailEquipment InstallRailEquipment { get; set; }//تجهیزاتی که بر روی ریل نصب می باشد: بصورت مولتی چک می باشد
        public float Maux { get; set; }//نیرو در ریل ناشی از بار تجهیزات جانبی


        public WallMaterialType WallMaterialType { get; set; }//نوع جنس دیوار
        public long WallMaterialTypeId { get; set; }
        public BedMaterialType BedMaterialType { get; set; }//نوع جنس کف
        public long BedMaterialTypeId { get; set; }

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
    }
}
