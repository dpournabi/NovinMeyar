using System;

namespace NovinMeyar.IdentityServer.Domain.DTO
{
    public class DefaultUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public string BranchCode { get; set; }
    }
}
