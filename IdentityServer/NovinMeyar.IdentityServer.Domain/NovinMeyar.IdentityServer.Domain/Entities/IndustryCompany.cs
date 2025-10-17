using System;

namespace NovinMeyar.IdentityServer.Domain.Entities
{
    public class IndustryCompany:BaseEntity
    {
        public long IndustryId { get; set; }
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsActive { get; set; }

        public Industry Industry { get; set; }
        public Company Company { get; set; }
        public Branch Branch { get; set; }
    }
}
