using NovinMeyar.Common;
using System;

namespace NovinMeyar.Technical.Domain.Contracts
{
    public class FastRegistrationSearch : Pagination
    {
        public string Id { get; set; }
        public string DocumentNumber { get; set; }
        public string BuildingCertificateNo { get; set; }//شماره پروانه ساختمانی*
        public string ResponsibleFullName { get; set; }//نام و نام خانوادگی هماهنگ کننده
        public DateTime? FromCreateDate { get; set; }//تاریخ ثبت
        public DateTime? ToCreateDate { get; set; }//تاریخ ثبت
        public long? InstallatinCompanyId { get; set; }//شرکت فروشنده
    }
}
