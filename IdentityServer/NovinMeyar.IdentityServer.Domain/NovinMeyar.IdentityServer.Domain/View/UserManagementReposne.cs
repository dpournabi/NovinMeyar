using System;

namespace NovinMeyar.IdentityServer.Domain.View
{
    public class UserManagementReposne
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string RoleName { get; set; }
        public string LocalRoleName { get; set; }
    }
}
