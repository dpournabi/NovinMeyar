namespace NovinMeyar.IdentityServer.Domain.View
{
    public class UserAccessLevelVM
    {
        public int Id { get; set; }
        public string AccessType { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
