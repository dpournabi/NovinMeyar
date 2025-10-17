using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class SetEmailRequest
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email format is incorrect")]
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
