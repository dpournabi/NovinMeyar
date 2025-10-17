using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.Entities.FiveSecurityParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// اطلاعات اسانسور
    /// </summary>
    public class ElevatorInformation : BaseEntity
    {
        public long BranchId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ElevatorNationalNo { get; set; }//شناسه ملی آسانسور*

        [Column(TypeName = "nvarchar(50)")]
        public string ISIRINo { get; set; }//کد رهگیری سامانه مدیریت*

        [Column(TypeName = "nvarchar(50)")]
        public string ResponsibleFullName { get; set; }//نام و نام خانوادگی هماهنگ کننده. نکته لزوما ایشان مشتری نمی باشند

        [Column(TypeName = "nvarchar(50)")]
        public string ResponsibleCell { get; set; }//تلفن هماهنگ کننده
        public bool IsActive { get; set; }
        public long ElevatorTypeId { get; set; }//نوع آسانسور
        public ElevatorType ElevatorType { get; set; }//نوع آسانسور
        public long? SerialResourceId { get; set; }
        /// <summary>
        /// x--> کششی اولیه:01
        /// کششی ادواری:02
        /// هیدرولیک اولیه: 03
        /// هیدرولیک ادواری: 04
        /// 05 : بازرسی کالا
        /// </summary>
        [Column(TypeName = "varchar(200)")]
        public string DocumentNumber { get; set; }//Format: {BranchCode}{x}{year(00)}/{Id}

        public virtual SerialResource SerialResource { get; set; }//سریال گواهی. به محض ست شدن پرونده لاک شود

        [Column(TypeName = "nvarchar(50)")]
        public string BuildingCertificateNo { get; set; }//شماره پروانه ساختمانی*

        [Column(TypeName = "nvarchar(50)")]
        public string BuildingPleque { get; set; }//شماره پلاک ثبتی*

        [Column(TypeName = "nvarchar(50)")]
        public string BuildingAreaNo { get; set; }//منطقه شهرداری*
        public DateTimeOffset BuildingIssueDate { get; set; }//تاریخ صدور پروانه ساختمان*

        [Column(TypeName = "nvarchar(50)")]
        public string InsuranceNo { get; set; }//شماره بیمه
        public DateTimeOffset? InsuranceIssueDate { get; set; }//تاریخ صدور بیمه
        public DateTimeOffset? ContractServiceStartDate { get; set; }//تاریخ قرارداد سرویس نگهداری
        public long InspectionTypeId { get; set; }//نوع بازرسی
        public InspectionType InspectionType { get; set; }//نوع بازرسی
        public long? LatestCertificateTypeId { get; set; }//گواهینامه قبلی-صادره از نما یا شرکت دیگر
        public LatestCertificateType LatestCertificateType { get; set; }//گواهینامه قبلی-صادره از نما یا شرکت دیگر
        public long CustomerId { get; set; }//شناسه مشتری*
        public bool CustomerType { get; set; }// 0: Real  1:Legal
        public long ProvinceId { get; set; }//استان
        public long CityId { get; set; }//شهر
        public string Address { get; set; }//آدرس
        public long InstallatinCompanyId { get; set; }//شرکت نصب کننده
        public InstallatinCompany InstallatinCompany { get; set; }//شرکت نصب کننده

        [Column(TypeName = "nvarchar(50)")]
        public string LuxMeterSerialNo { get; set; }//شماره اموال لوکس متر

        [Column(TypeName = "nvarchar(50)")]
        public string PowerMeterSerialNo { get; set; }//شماره اموال نیروسنج

        [Column(TypeName = "nvarchar(50)")]
        public string TypeMeterSerialNo { get; set; }//شماره اموال متر نواری

        [Column(TypeName = "nvarchar(50)")]
        public string MultiMeterSerialNo { get; set; }//شماره اموال مولتی متر

        [Column(TypeName = "nvarchar(50)")]
        public string LaserMeterSerialNo { get; set; }//شماره اموال متر لیزری

        [Column(TypeName = "nvarchar(50)")]
        public string CollisSerialNo { get; set; }//شماره اموال کولیس

        [Column(TypeName = "nvarchar(50)")]
        public string ThicknessGaugeSerialNo { get; set; }// شماره اموال ضخامت سنج

        public long? ScanDocumentId { get; set; }//شناسه فایل زیپ بارگذاری شده
        public long? ProjectDocumentId { get; set; }//شناسه فایل های پروژه
        public long? CertificateId { get; set; }//تصویر گواهینامه صادره
        public long? BuildingCertificateImageId { get; set; }//تصویر پروانه ساختمان
        public long? IsiriRequestImageId { get; set; }//تصویر درخواست سامانه بازرسی
        public int? StopCount { get; set; }//تعداد توقف
        public bool? IsLock { get; set; }//پس از تایید مدیر فنی این مقدار true می شود
        public string CreatorRoleName { get; set; }
        public string TechnicalInformation { get; set; }

        //One to one relationship
        public virtual SteelRopeInformation SteelRopeInformation { get; set; }
        public virtual EnginRoomInformation EngineInformation { get; set; }
        public virtual CounterWightAntiShocksInformations CounterWightAntiShocksInformations { get; set; }
        public virtual CabinAntiShocksInformations CabinAntiShocksInformations { get; set; }
        public virtual GovernerInformations GovernerInformations { get; set; }
        public virtual SafetyBrakesInformation SafetyBrakesInformation { get; set; }
        public virtual DoorLockInformation MechanicalDoorLockInformation { get; set; }
        public virtual RailsInformation RailsInformation { get; set; }
        public virtual CounterWeightInformation BalanceWeightInformation { get; set; }
        public virtual MainBoardInformation SteeringControlInformation { get; set; }
        public virtual CabinInformation CabinInformation { get; set; }
        public virtual GeneralTechnicalformation GeneralTechnicalformation { get; set; }
        public virtual ChainsCableInformation WroupsInformation { get; set; }
        public virtual TractionPulleiesInformation TractionPulleiesInformation { get; set; }

    }
}
