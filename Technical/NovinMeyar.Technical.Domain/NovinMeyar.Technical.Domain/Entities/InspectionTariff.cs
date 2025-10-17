using NovinMeyar.Common;
using System;

namespace NovinMeyar.Technical.Domain.Entities
{
    public class InspectionTariff:BaseEntity
    {
        public long InspectionTypeId { get; set; }//نوع بازرسی_اولیه / ادواری
        public int Step { get; set; }//مرحله بازرسی: بازرسی اول یا دوم و...
        public decimal Amount { get; set; }//تعرفه پرداخت
        public decimal AdditionalPayPerStopCount { get; set; }//تعرفه پرداخت مازاد بیش از 5 توقف
        public  DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InspectionType InspectionType { get; set; }//نوع بازرسی
    }
}
