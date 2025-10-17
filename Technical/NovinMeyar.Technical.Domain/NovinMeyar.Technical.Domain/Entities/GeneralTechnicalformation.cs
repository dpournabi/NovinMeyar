using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.CustomValidators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// اطلاعات فنی عمومی
    /// </summary>
    public class GeneralTechnicalformation : BaseEntity
    {
        public GeneralTechnicalformation()
        {
           this.CabinDoors = new HashSet<CabinDoor>(); 
           this.FloorDoorsInformations = new HashSet<FloorDoorsInformation>(); 
        }
        public int TypeOfStandard { get; set; }//نوع استاندارد آسانسور ویرایش قدیم:0 ویرایش جدید:1

        [Column(TypeName = "nvarchar(20)")]
        public string ElevatorPhoneNumber { get; set; }//شماره تلفن آسانسور
      
        public int FloorCount { get; set; }//تعداد طبقه
        public float FloorLength { get; set; }//طول طبقه

        /// <summary>
        /// Travel = (FloorCount-1)*FloorLength
        /// در صورتی که در حالت ویرایش ست شده باشد بتواند طول حرکت را به
        /// صورت دستی وارد نماید. نکته : به صورت پیش فرض باید روی حالت اتوماتیک باشد
        /// </summary>
        public bool ManualTravelCalculation { get; set; }//ویرایش
        public float Travel { get; set; }//طول حرکت
        public int ElevatorCount { get; set; }//تعداد آسانسور


        public float FrictionCoefficient { get; set; }//ضریب اصطکاک
        public float LowSpeed { get; set; }//سرعت کند کابین
        public float CabinSpeed { get; set; }//سرعت کابین
        public float PathHeight { get; set; }//ارتفاع مسیر حرکت
        public int RailsCount { get; set; }//تعداد ریل ها
        public float FrictionForceInsideCabin { get; set; }//نیروی اصطکاک در چاه سمت کابین
        public float FrictionForceInsideWeightBalance { get; set; }//نیروی اصطکاک در چاه سمت وزنه تعادل
        public float AccelerationEmergencyStop { get; set; }//شتاب ناشی از توقف اضطراری کابین
        public float OverHead { get; set; }//بالاسری
        public float DepthOfPit { get; set; }//عمق چاهک
        public float ShaftHeight { get; set; }//ارتفاع کل چاه
        public float ShaftDepth { get; set; }//عمق چاه
        public float ShaftWidth { get; set; }//عرض چاه
        public float CabinStandHeight { get; set; }//ارتفاع سکوی کابین
        public float CounterWeightStandHeight { get; set; }//ارتفاع سکوی وزنه تعادل
        public float StandsDistance { get; set; }//فاصله دو سکو
        public float CounterWeightToStandDistance { get; set; }//فاصله وزنه تا سکو

        [MinValue(50)]
        public int CabinToCounterWeightDistance { get; set; }//فاصله کابین تا وزنه_حداقل 50 میلیمتر

        public UseType UseType { get; set; }//کاربری آسانسور
        public decimal PullyDiameter { get; set; }//قطر فلکه هرزگرد
        public decimal TractionPullyEfficiency { get; set; }//راندمان فلکه هرزگرد
        public float MassDecreasedOfCable { get; set; }//جرم کاهش یافته فلکه کشش طناب جبران
        public float MassOfTractionPulley { get; set; }//جرم وسیله تامین کشش شامل جرم فلکه

        [Column(TypeName = "nvarchar(50)")]
        public string ThreePahseSerialNo { get; set; }//شماره سریال کنتور سه فاز

        [Column(TypeName = "nvarchar(50)")]
        public string UpSpeedControlDescription { get; set; }//توضیحات وسیله کنترل سرعت رو به بالا
        public bool HasIncpectorDoorInPit { get; set; }//درب بازرسی در چاهک: دارد ندارد
        public bool IsHalfCloseShaft { get; set; }//چاه نیمه پوشیده: هست نیست
        public bool HasShareShaft { get; set; }//چاه مشترک: دارد ندارد
        public bool HasEmergencyDoor { get; set; }//درب اضطراری: دارد ندارد
        public bool HasVisitFromShaft { get; set; }//دریچه بازدید از چاه: دارد ندارد
        public float MachineRoomHieght { get; set; }//ارتفاع سکو تا سقف موتورخانه
        public string TechnicalDescription { get; set; }//توضیحات فنی بازرس
        public bool PitSituation { get; set; }//وضعیت چاهک: 1 استوار 0 معلق

        /// <summary>
        /// به صورت پیش فرض باید مقدار این ویژگی پر باشد
        /// اگر مقدار این ویزگی ناصحیح بود
        /// </summary>
        public bool HasMachineRoom { get; set; }//موتورخانه
        public long MachineLocationId { get; set; }
        public LocationType MachineLocation { get; set; }//7
        public EngineAccessType EngineAccessType { get; set; }
        public bool HasOutsideBoard { get; set; }// آیا برد بیرون از چاه نصب شده: بله خیر
        public bool HasPullyRoom { get; set; }// آیا اتاق فلکه ها وجود دارد: بله خیر
        public string EmergencyExitDescription { get; set; }//توضیحات نحوه خروج ایمن و ابعاد آن

        public long GovernerLocationId { get; set; }
        public LocationType GovernerLocation { get; set; }

        //One to one relationship
        public IEnumerable<CabinDoor> CabinDoors {get; set;}
        public IEnumerable<FloorDoorsInformation> FloorDoorsInformations {get; set;}
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
