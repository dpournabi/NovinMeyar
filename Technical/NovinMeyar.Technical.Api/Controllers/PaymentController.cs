using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Views;
using Serilog;
using System;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IFastRegisrationRequestService fastRegisrationRequestService;
        public PaymentController(IFastRegisrationRequestService fastRegisrationRequestService)
        {
            this.fastRegisrationRequestService = fastRegisrationRequestService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> PrePaymentView()
        {
            var key = Request.Query["key"];
            Log.Information($"Key: {key}");
            //var _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(key)));
            //Log.Information($"_id: {_id}");
            var invoiceData = await fastRegisrationRequestService.GetDisplayInvoiceAsync(Guid.Parse(key));
            Log.Information($"invoiceData: {JsonConvert.SerializeObject(invoiceData)}");
            if (invoiceData == null)
            {
                Log.Information($"invoiceData = null");
                return NoContent();
            }
            Log.Information($"Data: {JsonConvert.SerializeObject(invoiceData.Data)}");
            return View((InvoiceInfoModel)invoiceData.Data);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
