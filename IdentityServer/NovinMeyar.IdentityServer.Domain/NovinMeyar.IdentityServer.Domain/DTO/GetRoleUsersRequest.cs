using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class GetRoleUsersRequest
    {
        [Required(ErrorMessage ="ارسال نام نقش اجباری می باشد")]
        public string RoleName { get; set; }
    }
}
