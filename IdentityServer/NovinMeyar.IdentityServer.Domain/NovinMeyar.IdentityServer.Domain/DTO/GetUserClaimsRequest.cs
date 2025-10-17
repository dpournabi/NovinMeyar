using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class GetUserClaimsRequest
    {
        [Required(ErrorMessage ="ارسال نام کاربری اجباری می باشد")]
        public string UserName { get; set; }
        public string ClaimType { get; set; }
    }
}
