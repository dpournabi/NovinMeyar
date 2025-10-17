using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.FileManagment.Api.Services.ver_1._0;
using NovinMeyar.FileManagment.Domain;
using NovinMeyar.Helpers;
using System.Net;
using System.Threading.Tasks;

namespace NovinMeyar.FileManagment.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class FileManagmentController: BaseController
    {
        private readonly IFileManagmentService fileManagmentService;
        public FileManagmentController(IFileManagmentService fileManagmentService)
        {
            this.fileManagmentService = fileManagmentService;
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveStreamAsync([FromForm] NormalFileStream normalFileStream)
        {
            var response = await fileManagmentService.SaveStreamAsync(normalFileStream, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLargeStreamAsync([FromForm] LargeFileStream largeFileStream)
        {
            var response = await fileManagmentService.SaveStreamAsync(largeFileStream, User.Identity.UserName());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ClaimRequirement]
        public async Task<IActionResult> DownloadFileAsync(long id)
        {
            var response = await fileManagmentService.GetStreamAsync(id);
            if (!response.Succeed)
                return StatusCode((int)HttpStatusCode.NotFound, response.Message);

            return File((byte[])response.ExteraInformation, response.Message);
        }

        [HttpGet("{id}")]
        [ClaimRequirement]
        public async Task<IActionResult> GenerateDownloadKeyAsync(long id)
        {
            var response = await fileManagmentService.GenerateDownloadKeyAsync(id, User.Identity.UserName());
            return Ok(response);
        }

        [HttpGet("{cipherKey}")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadLargeFileAsync(string cipherKey)
        {
            var response = await fileManagmentService.GetLargeStreamAsync(cipherKey);
            if (!response.Succeed)
                return Ok(response);

            return File((byte[])response.ExteraInformation, response.Message, response.Data.ToString());
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStreamAsync(long streamId)
        {
            var response = await fileManagmentService.DeleteStreamAsync(streamId, User.Identity.UserName(), User.Identity.RoleName());
            return Ok(response);
        }
    }
}
