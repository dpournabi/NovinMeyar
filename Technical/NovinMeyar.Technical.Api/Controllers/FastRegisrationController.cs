using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.DTO;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class FastRegisrationController : BaseController
    {
        private readonly IFastRegisrationRequestService fastRegisrationRequestService;
        public FastRegisrationController(IFastRegisrationRequestService fastRegisrationRequestService)
        {
            this.fastRegisrationRequestService = fastRegisrationRequestService;
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchAsync([FromBody] FastRegistrationSearch fastRegistrationSearch)
        {
            var response = await fastRegisrationRequestService.SearchAsync(fastRegistrationSearch, User.Identity.BranchId(), User.Identity.CurrentRoleIsAdmin(), User.Identity.CurrentUserRole(), User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync([FromBody] FastRegistrationModel request)
        {
            var response = await fastRegisrationRequestService.SaveAsync(request, User.Identity.UserName(), User.Identity.BranchId(), User.Identity.BranchCode(), User.Identity.BranchName(), User.Identity.CurrentUserRole(), User.Identity.CurrentRoleIsAdmin());
            return Ok(response);
        }

        [HttpPost]
        //[AllowAnonymous]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalExpert)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTechnicalInformationAsync([FromBody] TechnicalInformationModel model)
        {
            var response = await fastRegisrationRequestService.UpdateTechnicalInformationAsync(model, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        //[ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetDisplayInvoiceAsync(string tag)
        {
            var response = await fastRegisrationRequestService.GetDisplayInvoiceAsync(Guid.Parse(tag));
            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        //[ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> PrepareToPayAsync(string tag, CancellationToken cancellationToken)
        {
            var response = await fastRegisrationRequestService.PrepareToPayAsync(Guid.Parse(tag), User.Identity.UserName(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveAsync(long id)
        {
            var response = await fastRegisrationRequestService.DeactiveAsync(id, User.Identity.UserName());
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.Client)]
        [ProducesResponseType(typeof(ResponseModel<string>), 200)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetDocumentCategoriesAsync()
        {
            var response = await fastRegisrationRequestService.GetDocumentCategoriesAsync(User.Identity.CurrentUserRole());

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.Client)]
        [ProducesResponseType(typeof(ResponseModel<string>), 200)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetDocumentsAsync(string folderName)
        {
            var response = await fastRegisrationRequestService.GetDocumentsAsync(User.Identity.CurrentUserRole(), folderName);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.Client)]
        [ProducesResponseType(typeof(FileContentResult), 200)]
        public async Task<IActionResult> DownloadFileAsync(string folderName, string fileName)
        {
            var response = await fastRegisrationRequestService.DownloadFileAsync(User.Identity.CurrentUserRole(), folderName, fileName);
            return File((byte[])response.Data, response.ExteraInformation.ToString());
        }
    }
}
