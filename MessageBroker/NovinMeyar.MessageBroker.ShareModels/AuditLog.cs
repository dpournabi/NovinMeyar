using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Domain.Models
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TableName { get; set; }
        public string TablePK { get; set; }
        public string Data { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string AuditAction { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AuditUser { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
