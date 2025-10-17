using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Finance.Api.Services.ver_1._0;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.Finance.Api.Controllers
{
    public class PaymentBackController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly IRequestClient<UpdatePaymentStatusBroker> updatePaymentStatusClient;
        public readonly IPublishEndpoint publishEndpoint;

        public PaymentBackController(IPaymentService paymentService,
            IRequestClient<UpdatePaymentStatusBroker> updatePaymentStatusClient,
            IPublishEndpoint publishEndpoint)
        {
            this.paymentService = paymentService;
            this.updatePaymentStatusClient = updatePaymentStatusClient;
            this.publishEndpoint = publishEndpoint;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VerifyTransaction()
        {
            var tref = Request.Query["tref"];
            var iN = long.Parse(Request.Query["iN"]);
            var iD = Request.Query["iD"];
            Log.Write(Serilog.Events.LogEventLevel.Information, "Start CheckTransactionResultAsync successfully!");
            Log.Write(Serilog.Events.LogEventLevel.Information, $"tref:{tref} -- iN:{iN} -- iD:{iD}");
            var response = await paymentService.VerifyTransactionResultAsync(tref, iN, iD);
            if (response.IsSuccess)
            {
                _ = Task.Run(async () =>
                  {
                      await publishEndpoint.Publish<UpdatePaymentStatusBroker>(new UpdatePaymentStatusBroker
                      {
                          Success = response.IsSuccess,
                          SourceId = response.SourceId.Value,
                          PaymentDate = response.PaymentDate,
                          PaymentId = response.PaymentId
                      });
                  });
            }
            return View(response);
        }
    }
}
