using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class GetUserRolesRequest
    {
        [Required(ErrorMessage ="ارسال نام کاربری اجباری می باشد")]
        public string UserName { get; set; }
    }
}
