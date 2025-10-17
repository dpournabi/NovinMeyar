using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace NovinMeyar.Common.CustomAuthorize
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var currentRoleIsAdmin = bool.Parse(context.HttpContext.User.Claims.First(x => x.Type == "CurrentRoleIsAdmin").Value);
            var currentRoleIsRoot = bool.Parse(context.HttpContext.User.Claims.First(x => x.Type == "CurrentRoleIsRoot").Value);
            if (!currentRoleIsAdmin && !currentRoleIsRoot)
            {
                var describer = (ControllerActionDescriptor)context.ActionDescriptor;
                var action = $"{describer.ControllerName}.{describer.ActionName}";

                var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == "Permission" && c.Value == action);
                if (!hasClaim)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
