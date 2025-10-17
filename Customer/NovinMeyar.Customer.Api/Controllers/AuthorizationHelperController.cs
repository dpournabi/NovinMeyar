using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NovinMeyar.Customer.Api.Controllers
{
    [Authorize(Roles = AssessorsManager.Root)]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AuthorizationHelperController : BaseController
    {
        [HttpGet]
        public IActionResult GetAllActions()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var controllers = assembly.GetTypes()
                .Where(x => x.BaseType != null &&
                           x.BaseType.Name == "BaseController" &&
                           x.Name != "AuthorizationHelperController")
                .Select(x => x.Name.Replace("Controller", ""))
                .ToList();

            var methods = new List<string>();
            foreach (var controllerName in controllers)
            {
                var controllerObject = assembly.GetTypes().First(x => x.Name == string.Concat(controllerName, "Controller"));
                methods.AddRange(controllerObject.GetMethods()
                .Where(method => method.IsPublic &&
                       !method.IsDefined(typeof(NonActionAttribute)) &&
                       (method.ReturnType != null && method.ReturnType.FullName.Contains("IActionResult")))
                .Select(x => $"{controllerName}.{x.Name.Replace("Async", "")}")
                .ToList());
            }
            return Ok(methods);
        }
    }
}
