using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.IdentityServer.Domain.Entities
{
    public class ApplicationRole:IdentityRole<Guid>
    {
        [Column(TypeName = "nvarchar(50)")]
        public string LocalName { get; set; }
    }
}
