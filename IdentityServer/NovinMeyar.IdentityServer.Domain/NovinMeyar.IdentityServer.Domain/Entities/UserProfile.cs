using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.IdentityServer.Domain.Entities
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string OfficeTell { get; set; }

        public string OfficeAddress { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string HomeTell { get; set; }

        public string HomeAddress { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string CellPhone { get; set; }

        public DateTime ExpirationContract { get; set; }
        [NotMapped]
        public IEnumerable<byte[]> Guarantees { get; private set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
