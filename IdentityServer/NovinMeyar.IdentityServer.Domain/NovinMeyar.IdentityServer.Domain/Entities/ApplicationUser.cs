using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.IdentityServer.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ConfirmationPhoneNumberCode { get; set; }
        public bool ConfirmByAdmin { get; set; }
        public long? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
