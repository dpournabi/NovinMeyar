using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Customer.Api.Services.ver_1._0;
using NovinMeyar.Customer.Domain;
using NovinMeyar.Customer.Domain.Entities;
using NovinMeyar.Helpers;
using System.Threading.Tasks;

namespace NovinMeyar.Customer.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CustomerController : BaseController
    {
        private readonly ILegalCustomerService legalCustomerService;
        private readonly IRealCustomerService realCustomerService;
        public CustomerController(ILegalCustomerService legalCustomerService,
            IRealCustomerService realCustomerService)
        {
            this.legalCustomerService = legalCustomerService;
            this.realCustomerService = realCustomerService;
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchLegalCustomersAsync([FromBody] LegalSearch legalSearch)
        {
            var response = await legalCustomerService.SearchAsync(legalSearch, User.Identity.BranchId(), User.Identity.CurrentRoleIsAdmin(), User.Identity.UserName(), User.Identity.CurrentUserRole());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLegalCustomerAsync([FromBody] LegalCustomer legalCustomer)
        {
            var response = await legalCustomerService.SaveAsync(legalCustomer, User.Identity.BranchId(), User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveLegalCustomerAsync(long customerId)
        {
            var response = await legalCustomerService.DeactiveAsync(customerId, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchRealCustomersAsync([FromBody] RealSearch realSearch)
        {
            var response = await realCustomerService.SearchAsync(realSearch, User.Identity.BranchId(), User.Identity.CurrentRoleIsAdmin(), User.Identity.UserName(), User.Identity.CurrentUserRole());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRealCustomerAsync([FromBody] RealCustomer realCustomer)
        {
            var response = await realCustomerService.SaveAsync(realCustomer, User.Identity.BranchId(), User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveRealCustomerAsync(long customerId)
        {
            var response = await realCustomerService.DeactiveAsync(customerId, User.Identity.UserName());
            return Ok(response);
        }
    }
}
