using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class ForgetPasswordRequest
    {
        [MaxLength(11)]
        public string Username { get; set; }
    }
}
