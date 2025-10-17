using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.IdentityServer.Domain
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserCreatorName { get; set; }
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserModifiedName { get; set; }
        public DateTime? UserModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
