using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class TokenRequest
    {
        [MaxLength(100)]
        public string client_id { get; set; }
        [MaxLength(100)]
        public string client_secret { get; set; }
        [MaxLength(100)]
        public string scope { get; set; }
        [MaxLength(100)]
        public string grant_type { get; set; }
        [MaxLength(100)]
        public string username { get; set; }
        [MaxLength(100)]
        public string password { get; set; }
    }
}
