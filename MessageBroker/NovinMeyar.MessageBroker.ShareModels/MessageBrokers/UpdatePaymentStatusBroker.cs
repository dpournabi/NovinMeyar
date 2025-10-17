using System;

namespace NovinMeyar.Common.MessageBrokers
{
    public class UpdatePaymentStatusBroker
    {
        public bool Success { get; set; }
        public long SourceId { get; set; }
        public Guid? PaymentId { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
    }
}
