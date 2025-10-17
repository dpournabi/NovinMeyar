using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class EmailConfirmationRequest
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email format is incorrect")]
        public string Email { get; set; }
    }
}
