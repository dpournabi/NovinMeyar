using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Cartabl.Api.Services.ver_1._0;
using NovinMeyar.Cartabl.Domain.CommentModels;
using NovinMeyar.Cartabl.Domain.SearchModels;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class BaseInformationController : BaseController
    {
        private readonly IBaseInformationService baseInformationService;
        public BaseInformationController(IBaseInformationService baseInformationService)
        {
            this.baseInformationService = baseInformationService;
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetRequestTypesAsync()
        {
            var response = await baseInformationService.GetRequestTypesAsync();
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);

            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> SearchRequestAsync(RequestSearch requestSearch)
        {
            var response = await baseInformationService.SearchRequestAsync(requestSearch, User.Identity.BranchId(), User.Identity.CurrentRoleIsAdmin(), User.Identity.UserName(), User.Identity.CurrentUserRole());
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> RequestTypesPagedAsync(RequestTypesSearch requestTypesSearch)
        {
            var response = await baseInformationService.RequestTypesPagedAsync(requestTypesSearch);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> ConfirmationAsync(string id)
        {
            var response = await baseInformationService.ConfirmationAsync(id, User.Identity.CurrentUserRole());
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> RejectAsync(string id)
        {
            var response = await baseInformationService.RejectAsync(id, User.Identity.CurrentUserRole());
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> SeenRequestAsync(string id)
        {
            var response = await baseInformationService.SeenRequestAsync(id);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.Root)]
        public async Task<IActionResult> UndoRequestStateAsync(long id)
        {
            var response = await baseInformationService.UndoRequestStateAsync(id);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> CreateComment(string id, [FromBody] RequestComment model)
        {
            var response = await baseInformationService.RejectAsync(id, User.Identity.CurrentUserRole());
            if (response.Succeed)
                await baseInformationService.CreateCommentAsync(id, User.Identity.UserName(), model);

            return Ok(response);
        }
        [HttpGet]
        [Authorize(Roles = AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.Root + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> GetComments(string id)
        {

           var response= await baseInformationService.GetCommentsAsync(id);

            return Ok(response);
        }

    }
}
