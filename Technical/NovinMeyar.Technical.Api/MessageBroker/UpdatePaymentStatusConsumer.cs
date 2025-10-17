using MassTransit;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.MessageBroker
{
    public class UpdatePaymentStatusConsumer : IConsumer<UpdatePaymentStatusBroker>
    {
        private readonly IElevatorInspectionService elevatorInspectionService;
        public UpdatePaymentStatusConsumer(IElevatorInspectionService elevatorInspectionService)
        {
            this.elevatorInspectionService = elevatorInspectionService;
        }
        public async Task Consume(ConsumeContext<UpdatePaymentStatusBroker> context)
        {
            var result = context.Message;
            if(result.Success)
            {
                var elevatorInspection = await elevatorInspectionService.GetAsync(result.SourceId);
                await elevatorInspectionService.UpdatePaymentStateAsync(result.SourceId, result.PaymentId, result.PaymentDate);
            }
        }
    }
}
