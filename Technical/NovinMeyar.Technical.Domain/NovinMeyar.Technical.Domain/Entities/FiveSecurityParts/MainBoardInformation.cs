using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities.FiveSecurityParts
{
    /// <summary>
    /// سیستم کنترل فرمان
    /// </summary>
    public class MainBoardInformation : BaseEntity
    {
        public ObjectDetail BoardType { get; set; }//نام سازنده
        public long BoardTypeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SerialNo { get; set; }// شماره سریال

        public long TravelingCableTypeId { get; set; }
        public ObjectDetail TravelingCableType { get; set; }//نوع تروال کابل
        
        public int CableCount { get; set; }//تعداد کابل
        public int LineCount { get; set; }//تعداد رشته
        public float CableTickness { get; set; }//ضخامت رشته که به صورت پیش فرض 0.75 می باشد ولی توسط بازرس قابل تغییر می باشد
        public bool Drive { get; set; }//وسیله تغییر سرعت پیوسته
        public bool Deliverance { get; set; }//سیستم نجات اضطراری

        /// <summary>
        ///  اگر مقدار این پراپرتی صحیح بود که هیچ ولی اگه ناصحیح بود محاسبات نیروی فلایویل انجام گردد و 
        ///  در صورتی که مقدار این عدد از 400 نیوتن بیشتر بود پیغام "استفاده از کلید برقی اضطراری برای این آسانسور الزامی می باشد"
        ///  به صورت الارم نمایش داده شود
        /// </summary>
        public bool HasEmergencyKey { get; set; }//کلید برقی اضطراری دارد ندارد.
                                                 //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
