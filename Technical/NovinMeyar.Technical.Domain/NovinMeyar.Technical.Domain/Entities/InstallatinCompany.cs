using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// لیست شرکت های فروشنده
    /// </summary>
    public class InstallatinCompany:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EconomicCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string RegistrationNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NationalNo { get; set; }
        public long DesigningCertificateId { get; set; }//شناسه فایل تصویر پروانه طراحی
        public long RegistrationOfficeCertificate { get; set; }//تصویر استعلام اداره ثبت

        [Column(TypeName = "nvarchar(20)")]
        public string TellPhone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CTOFirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CTOLastName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CTOCell { get; set; }//موبایل مدیرعامل
        public DateTime? CTOBirthDate { get; set; }
        public string Address { get; set; }

    }
}
