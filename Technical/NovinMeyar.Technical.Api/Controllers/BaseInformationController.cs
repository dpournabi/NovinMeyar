using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Helpers;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
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

        [HttpPost]
        [ClaimRequirement]
        public async Task<IActionResult> SearchAsync([FromBody] BaseInformationSearch search)
        {
            var response = await baseInformationService.SearchAsync(search);
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetObjectDetailItemsAsync(long id)
        {
            var response = await baseInformationService.GetObjectDetailItemsAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        public async Task<IActionResult> SearchPropertyAsync([FromBody] SearchProperty search)
        {
            var response = await baseInformationService.SearchPropertyAsync(search);
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetTreeAsync()
        {
            var response = await baseInformationService.GetTreeAsync();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> SaveAsync([FromBody] ObjectDetail model)
        {
            var response = await baseInformationService.SaveAsync(model, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> DeactiveAsync(long objectDetailId)
        {
            var response = await baseInformationService.DeactiveAsync(objectDetailId, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> DeactiveObjectDetailPropertyAsync(long objectDetailPropertyId)
        {
            var response = await baseInformationService.DeactiveObjectDetailPropertyAsync(objectDetailPropertyId, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> SavePropertyAsync([FromBody] Property model)
        {
            var response = await baseInformationService.SavePropertyAsync(model, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> DeletePropertyAsync(long id)
        {
            var response = await baseInformationService.DeletePropertyAsync(id, User.Identity.UserName());
            return Ok(response);
        }


        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetInspectionTypesAsync()
        {
            var response = await baseInformationService.GetInspectionTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetLatestCertificateTypesAsync()
        {
            var response = await baseInformationService.GetLatestCertificateTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetElevatorTypesAsync()
        {
            var response = await baseInformationService.GetElevatorTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetBrakeTypesAsync()
        {
            var response = await baseInformationService.GetBrakeTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetCabinAntiShockTypesAsync()
        {
            var response = await baseInformationService.GetCabinAntiShockTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetCounterWeightAntiShockTypesAsync()
        {
            var response = await baseInformationService.GetCounterWeightAntiShockTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetCounterWeightTypesAsync()
        {
            var response = await baseInformationService.GetCounterWeightTypesAsync();
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        public async Task<IActionResult> GetDoorTypesAsync(bool isCabin)
        {
            var response = await baseInformationService.GetDoorTypesAsync(isCabin);
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetInstallationTypesAsync()
        {
            var response = await baseInformationService.GetInstallationTypesAsync();
            return Ok(response);
        }

        [HttpGet]
        [ClaimRequirement]
        public async Task<IActionResult> GetWeightShoesTypesAsync()
        {
            var response = await baseInformationService.GetWeightShoesTypesAsync();
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        public async Task<IActionResult> GetLocationTypesAsync(byte LocationEnum)
        {
            var response = await baseInformationService.GetLocationTypesAsync(LocationEnum);
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        public async Task<IActionResult> FindLocationTypeAsync(string title)
        {
            var response = await baseInformationService.FindLocationTypeAsync(title);
            return Ok(response);
        }
    }
}
