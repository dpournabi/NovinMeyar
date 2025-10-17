using System;

namespace NovinMeyar.Technical.Domain.Views
{
    public class VMFastRegistration
    {
        public long Id { get; set; }
        public long? BranchId { get; set; }
        public string ElevatorNationalNo { get; set; }//شناسه ملی آسانسور*
        public string ISIRINo { get; set; }//کد رهگیری سامانه مدیریت*
        public string ResponsibleFullName { get; set; }//نام و نام خانوادگی هماهنگ کننده. نکته لزوما ایشان مشتری نمی باشند
        public string ResponsibleCell { get; set; }//تلفن هماهنگ کننده
        public bool IsActive { get; set; }
        public long? ElevatorTypeId { get; set; }//نوع آسانسور
        public long? SerialResourceId { get; set; }
        /// <summary>
        /// x--> کششی اولیه:01
        /// کششی ادواری:02
        /// هیدرولیک اولیه: 03
        /// هیدرولیک ادواری: 04
        /// 05 : بازرسی کالا
        /// </summary>
        public string DocumentNumber { get; set; }//Format: {BranchCode}{x}{year(00)}/{Id}
        public string BuildingCertificateNo { get; set; }//شماره پروانه ساختمانی*
        public string BuildingPleque { get; set; }//شماره پلاک ثبتی*
        public string BuildingAreaNo { get; set; }//منطقه شهرداری*
        public DateTimeOffset? BuildingIssueDate { get; set; }//تاریخ صدور پروانه ساختمان*
        public string InsuranceNo { get; set; }//شماره بیمه
        public DateTimeOffset? InsuranceIssueDate { get; set; }//تاریخ صدور بیمه
        public DateTimeOffset? ContractServiceStartDate { get; set; }//تاریخ قرارداد سرویس نگهداری
        public long InspectionTypeId { get; set; }//نوع بازرسی
        public long? LatestCertificateTypeId { get; set; }//گواهینامه قبلی-صادره از نما یا شرکت دیگر
        public long? CustomerId { get; set; }//شناسه مشتری*
        public bool CustomerType { get; set; }// نوع مشتری 0:حقیقی 1: حقوقی
        public string CustomerFullName { get; set; }
        public string CompanyName { get; set; }
        public string ProvinceName { get; set; }//استان
        public string CityName { get; set; }//شهر
        public string Address { get; set; }//آدرس
        public string LuxMeterSerialNo { get; set; }//شماره اموال لوکس متر
        public string PowerMeterSerialNo { get; set; }//شماره اموال نیروسنج
        public string TypeMeterSerialNo { get; set; }//شماره اموال متر نواری
        public string MultiMeterSerialNo { get; set; }//شماره اموال مولتی متر
        public string LaserMeterSerialNo { get; set; }//شماره اموال متر لیزری
        public string CollisSerialNo { get; set; }//شماره اموال کولیس
        public string ThicknessGaugeSerialNo { get; set; }// شماره اموال ضخامت سنج
        public string ElevatorTypeName { get; set; }
        public string InspectionTypeName { get; set; }
        public string InstallatinCompanyName { get; set; }
        public long? InstallatinCompanyId { get; set; }
        public int? StopCount { get; set; }
        //public DateTime? InspectionDate { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ScanDocumentId { get; set; }
        public long? ProjectDocumentId { get; set; }
        public long? CertificateId { get; set; }
        public bool Deleted { get; set; }
        public string UserCreatorName { get; set; }
        public long? BuildingCertificateImageId { get; set; }
        public long? IsiriRequestImageId { get; set; }
        public bool? IsLock { get; set; }
    }
}
