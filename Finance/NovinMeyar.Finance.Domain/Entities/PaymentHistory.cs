using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Finance.Domain.Entities
{
    public class PaymentHistory
    {  
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Tag { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string SourceTable { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string SourceKey { get; set; }

        public bool IsSuccess { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Message { get; set; }//پیغام
        public long ReferenceNumber { get; set; }//شماره ارجاع
        public int TraceNumber { get; set; }//شماره پیگیری

        [Column(TypeName = "nvarchar(20)")]
        public string TransactionDate { get; set; }//تاریخ تراکنش

        [Column(TypeName = "varchar(5)")]
        public string Action { get; set; }//1003 خرید

        [Column(TypeName = "nvarchar(50)")]
        public string TransactionReferenceID { get; set; }//شماره ارجاع داخلی

        public long InvoiceNumber { get; set; }//شماره فاکتور

        [Column(TypeName = "nvarchar(20)")]
        public string InvoiceDate { get; set; }//تاریخ فاکتور
        public int MerchantCode { get; set; }//شماره پذیرنده_نام کاربری
        public int TerminalCode { get; set; }//شماره ترمینال_رمز عبور
        public decimal Amount { get; set; }//مبلغ تراکنش
        public string MaskedCardNumber { get; set; }
        public string HashedCardNumber { get; set; }
        public string ShaparakRefNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CreatorUserName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        public string ExteraInformation { get; set; }

        public bool Deleted { get; set; }
    }
}
