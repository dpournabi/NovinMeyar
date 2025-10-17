using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovinMeyar.Common;
using NovinMeyar.Finance.Api.Services.ver_1._0;
using NovinMeyar.Finance.Domain.DTO;
using Serilog;
using System.Threading.Tasks;

namespace NovinMeyar.Finance.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetTokenAsync([FromBody] PaymentRequestModel model)
        {
            var response = await paymentService.GetTokenAsync(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> VerifyTransactionAsync([FromRoute] string tref, long iN, string iD)
        {
            Log.Write(Serilog.Events.LogEventLevel.Information, "Start CheckTransactionResultAsync successfully!");
            Log.Write(Serilog.Events.LogEventLevel.Information, $"tref:{tref} -- iN:{iN} -- iD:{iD}");
            var response = await paymentService.VerifyTransactionResultAsync(tref, iN, iD);
            return Ok(response);
        }
    }
}
