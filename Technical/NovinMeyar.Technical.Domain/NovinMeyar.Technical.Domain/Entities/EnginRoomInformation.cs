using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// اطلاعات موتور
    /// </summary>
    public class EnginRoomInformation : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string SerialNo { get; set; }//سریال موتور
        public ObjectDetail EngineType { get; set; }//نام سازنده موتور
        public long EngineTypeId { get; set; }
        public ObjectDetail GeerType { get; set; }//نام سازنده گیربکس
        public long GeerTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ModelName { get; set; }//نام مدل
        public decimal NuminalStream { get; set; }//جریان نامی
        public decimal StartStream { get; set; }//جریان راه اندازی
        public float OutputPower { get; set; }//توان خروجی
        public int HighSpeed { get; set; }//دورتند بر دقیقه
        public int LowSpeed { get; set; }//دورکند بر دقیقه
        public float GeerRatio { get; set; }//نسبت تبدیل گیربکس


        /// <summary>
        ///  اگر مقدار این پراپرتی صحیح بود که هیچ ولی اگه ناصحیح بود محاسبات نیروی فلایویل انجام گردد و 
        ///  در صورتی که مقدار این عدد از 400 نیوتن بیشتر بود پیغام "استفاده از کلید برقی اضطراری برای این آسانسور الزامی می باشد"
        ///  به صورت الارم نمایش داده شود
        /// </summary>
        public bool HasGeer { get; set; }//گیربکس دار- بدون گیربکس
        public float EngineWeight { get; set; }//جرم موتور و متعلقات**
        public float EngineSpeed { get; set; }//سرعت موتور

        /// <summary>
        /// اگر مقدار این پراپرتی صحیح بود به این مفهوم اسن که
        /// محاسبات موتور باید از فرمول شماره یک صفحه دوم چک لیست محاسبه شود
        /// EngineSpeed = (TractionPullyDiameter*System.Math.PI*HighSpeed*GeerRatio)/(60*ConversionRatio)
        /// </summary>
        public bool ManualEngineSpeed { get; set; }//محاسبه دستی سرعت موتور
        public decimal MaxPressureOnTractionPullyEfficiency { get; set; }//حداکثر بار استاتیکی مجاز روی فلکه کشش**
        public int RopeCountOnTractionPullyEfficiency { get; set; }//تعداد پیچش طنابها روی فلکه کشش
        public float BetaAngle { get; set; }//زاویه بتا
        public bool UnderCut { get; set; }//زیربرش
        public char GrooveType { get; set; }//نوع شیار: U or V
        public float GammaAngle { get; set; }//زاویه گاما
        public int GearboxEfficiency { get; set; }//راندمان گیربکس
        public bool GrooveMeachanics { get; set; }//سخت کاری شیار 
        public int GripesCount { get; set; }//تعداد پیچش طناب روی فلکه
        public int GrooveCount { get; set; }//تعداد شیارهای فلکه رانش موتور

        /// <summary>
        /// ////////////////////////////////////////////////محاسبات آلفا ///////////////////
        /// </summary>

        /// <summary>
        /// در صورت صحیح بودن این مقدار به این مفهوم است که محاسبات به صورت 
        /// دستی انجام می شود که فرمول آن به شرح دیل می باشد
        /// AlphaResult=(ManualAlphaLength/System.Math.PI*TractionPullyDiameter)*360
        /// </summary>
        public bool ManualCalculation { get; set; }//محاسبه دستی
        public decimal TractionPullyDiameter { get; set; }//قطر فلکه رانش برحسب میلیمتر_شماره یک
        public decimal ManualAlphaLength { get; set; }//خواب سیم بکسل روی فلکه کشش برحسب میلیمتر_شماره دو
        public float AlphaAngle { get; set; }//زاویه آلفا
        public decimal VerticalDistanceWires { get; set; }//فاصله عمودی مرکز فلکه ها(V)
        public decimal HorizontalDistanceWires { get; set; }//فاصل افقی دو بکسل(بکسل تا بکسل)
        public float ConversionRatio { get; set; }//ضریب بکسل بندی
        public decimal AlphaResult { get; set; }//الفای محاسبه شده
        public float CounterWeightDistanceToWall { get; set; }//فاصله بکسل وزنه تا دیوار
        public float CounterWeightDistanceToNextWall { get; set; }//فاصله بکسل وزنه تا دیوار جانبی
        public float GavernerDistanceToWall { get; set; } //فاصله گاورنر تا دیوار-Y
        public float GavernerDistanceToNextWall { get; set; }//فاصله گاورنر تا دیوار جانبی-X
        public LocationType GovernerLocationType { get; set; }
        public long GovernerLocationTypeId { get; set; }//جانمایی گاورنر نسبت به ورودی چاهک

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
