using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Customer.Domain.Entities
{
    /// <summary>
    /// مشتری حقوقی
    /// </summary>
    public class LegalCustomer:BaseEntity
    {
        public long BranchId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }//کد اختصاصی

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string EconomicCode { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string RegisterNo { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string NationalCode { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TellPhone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CEOFirstName { get; set; }//نام مدیرعامل

        [Column(TypeName = "nvarchar(20)")]
        public string CEOCell { get; set; }//شماره همراه

        [Column(TypeName = "nvarchar(50)")]
        public string CEOLastName { get; set; }//نام خانوادگی مدیرعامل
        public DateTime? CEOBirthday { get; set; }//تاریخ تولد مدیرعامل
        public string Address { get; set; }
    }
}
