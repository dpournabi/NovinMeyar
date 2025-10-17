namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class NewClaimRequest
    {
        public int Id { get; set; }
        public string AccessType { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
    public class AddClaimRequest
    {
        public string UsernameOrRolename { get; set; }
        public NewClaimRequest NewClaimRequest { get; set; }
    }
    public class AddClaimRequests
    {
        public string UsernameOrRolename { get; set; }
        public NewClaimRequest NewClaimRequest { get; set; }
    }
}
