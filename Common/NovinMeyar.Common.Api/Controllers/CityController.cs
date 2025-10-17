using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common;
using NovinMeyar.Common.Domain;
using NovinMeyar.FileManagment.Api.Services.ver_1._0;
using System.Threading.Tasks;

namespace NovinMeyar.Customer.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CityController : BaseController
    {
        private readonly IProvinceService provinceService;
        public CityController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetProvincesAsync([FromBody] SearchProvince search)
        {
            var response = await provinceService.GetProvincesAsync(search);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);

            return Ok(response);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCitiesAsync([FromBody] SearchCity search)
        {
            var response = await provinceService.GetCitiesAsync(search);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);

            return Ok(response);
        }
    }
}
