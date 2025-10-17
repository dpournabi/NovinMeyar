using System;

namespace NovinMeyar.Technical.Domain.DTO
{
    /// <summary>
    /// ثبت سریع پرونده
    /// </summary>
    public class FastRegistrationModel
    {
        public long Id { get; set; }
        public long? RequestTypeId { get; set; }//نوع درخواست
        public string RequestTitle { get; set; }//عنوان درخواست
        public long? ElevatorTypeId { get; set; }//نوع آسانسور
        public long? InspectionTypeId { get; set; }//نوع بازرسی
        public long? LatestCertificateTypeId { get; set; }//گواهینامه قبلی-صادره از نما یا شرکت دیگر
        public string ResponsibleFullName { get; set; }//نام و نام خانوادگی هماهنگ کننده. نکته لزوما ایشان مشتری نمی باشند
        public string ResponsibleCell { get; set; }//تلفن هماهنگ کننده
        public string ElevatorNationalNo { get; set; }//شناسه ملی آسانسور*
        public string ISIRINo { get; set; }//کد رهگیری سامانه مدیریت*
        public string BuildingCertificateNo { get; set; }//شماره پروانه ساختمانی*
        public string BuildingPleque { get; set; }//شماره پلاک ثبتی*
        public string BuildingAreaNo { get; set; }//منطقه شهرداری*

        private DateTimeOffset? _BuildingIssueDate;
        public DateTimeOffset? BuildingIssueDate 
        { 
            get 
            { 
                return this._BuildingIssueDate.Value.ToLocalTime(); 
            }
            set
            {
                _BuildingIssueDate = value;
            } 
        }//تاریخ صدور پروانه ساختمان*
        //تاریخ بازرسی
        public DateTimeOffset? InspectionDate { get; set; }
        public long? CustomerId { get; set; }//شناسه مشتری*
        public bool CustomerType { get; set; }//0:Real  1:Legal
        public long? ProvinceId { get; set; }//استان
        public long? CityId { get; set; }//شهر
        public string Address { get; set; }//آدرس
        public long? InstallatinCompanyId { get; set; }//شناسه شرکت فروشنده
        public long? ScanDocumentId { get; set; }//شناسه فایل زیپ بارگذاری شده
        public long? ProjectDocumentId { get; set; }//شناسه فایل های پروژه
        public long? CertificateId { get; set; }//تصویر گواهینامه صادره
        public long? BuildingCertificateImageId { get; set; }//تصویر پروانه ساختمان
        public long? IsiriRequestImageId { get; set; }//تصویر درخواست سامانه بازرسی
        public int? StopCount { get; set; }
        public long? BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
