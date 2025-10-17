using System;
using Serilog;
using MassTransit;
using System.Threading.Tasks;
using NovinMeyar.Finance.Domain.DTO;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Finance.Api.Services.ver_1._0;

namespace NovinMeyar.Finance.Api.MessageBroker
{
    public class GetTokenConsumer : IConsumer<GetPaymentTokenBroker>
    {
        private readonly IPaymentService paymentService;
        public GetTokenConsumer(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        public async Task Consume(ConsumeContext<GetPaymentTokenBroker> context)
        {
            try
            {
                var model = new PaymentRequestModel
                {
                    Amount = context.Message.Amount,
                    InvoiceNumber = context.Message.InvoiceNumber,
                    SourceKey = context.Message.SourceKey,
                    SourceTable = context.Message.SourceTable,
                    CreatorUserName = context.Message.CreatorUserName,
                    CreateDate = context.Message.CreateDate,
                    Tag = context.Message.Tag,
                    DataFlag = context.Message.DataFlag
                };
                var response = await paymentService.GetTokenAsync(model);
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(GetTokenConsumer)} --> {nameof(Consume)} --> Error deatail");
            }
        }
    }
}
