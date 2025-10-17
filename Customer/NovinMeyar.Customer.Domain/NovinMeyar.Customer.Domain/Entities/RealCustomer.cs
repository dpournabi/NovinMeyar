using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Customer.Domain.Entities
{
    /// <summary>
    /// مشتری حقیقی
    /// </summary>
    public class RealCustomer:BaseEntity
    {
        public long BranchId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }//کد اختصاصی

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string NationalCode { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TellPhone { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string CellPhone { get; set; }
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PostalCode { get; set; }
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ExteraInformation { get; set; }

        //[Required(ErrorMessage ="ارسال تصویر کارت ملی الزامی می باشد")]
        public long? NationalCartId { get; set; }
    }
}
