using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.DTO;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ElevatorInspectionController : BaseController
    {
        private readonly IElevatorInspectionService elevatorInspectionService;
        public ElevatorInspectionController(IElevatorInspectionService elevatorInspectionService)
        {
            this.elevatorInspectionService = elevatorInspectionService;
        }

        [HttpGet]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAsync(long id)
        {
            var response = await elevatorInspectionService.GetAsync(id);
            return Ok(response);
        }


        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync([FromBody] ElevatorInspectionModel request)
        {
            var response = await elevatorInspectionService.SaveAsync(request, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalExpert)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> NotifyAsync(NotifyModel notifyModel)
        {
            var response = await elevatorInspectionService.NotifyAsync(notifyModel);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveAsync(long id)
        {
            var response = await elevatorInspectionService.DeactiveAsync(id, User.Identity.UserName());
            return Ok(response);
        }
    }
}
