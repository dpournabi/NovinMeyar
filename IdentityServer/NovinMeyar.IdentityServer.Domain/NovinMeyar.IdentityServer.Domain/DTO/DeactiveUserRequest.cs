using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class DeactiveUserRequest
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
    }
}
