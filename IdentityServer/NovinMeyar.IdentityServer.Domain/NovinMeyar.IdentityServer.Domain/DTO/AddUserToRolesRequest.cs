using System.Collections.Generic;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class AddUserToRolesRequest
    {
        public IEnumerable<string> Roles { get; set; }
    }
}
