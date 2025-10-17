using Microsoft.AspNetCore.Mvc;

namespace NovinMeyar.Common.CustomAuthorize
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute() : base(typeof(ClaimRequirementFilter))
        {
        }
    }
}
