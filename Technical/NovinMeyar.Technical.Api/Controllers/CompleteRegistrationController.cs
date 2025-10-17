using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.DTO;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CompleteRegistrationController : BaseController
    {
        private readonly ICompleteRegisrationRequestService completeRegisrationRequestService;
        public CompleteRegistrationController(ICompleteRegisrationRequestService completeRegisrationRequestService)
        {
            this.completeRegisrationRequestService = completeRegisrationRequestService;
        }

        //[HttpPost]
        //[ClaimRequirement]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SaveAsync([FromBody] TechnicalInformationModel request)
        //{
        //    var response = await completeRegisrationRequestService.CompleteAsync(request, User.Identity.UserName(), User.Identity.BranchId(), User.Identity.BranchCode());
        //    return Ok(response);
        //}

        [HttpGet]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAsync([FromQuery] long Id)
        {
            var response = await completeRegisrationRequestService.GetAsync(Id);
            return Ok(response);
        }
    }
}
