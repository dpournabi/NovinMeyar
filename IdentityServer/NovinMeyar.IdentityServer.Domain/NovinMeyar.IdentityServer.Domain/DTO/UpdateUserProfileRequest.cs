namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class UpdateUserProfileRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
    }
}
