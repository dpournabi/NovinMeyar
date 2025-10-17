namespace NovinMeyar.IdentityServer.Domain.View
{
    public class GetAllRoleClaimsResponse
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
