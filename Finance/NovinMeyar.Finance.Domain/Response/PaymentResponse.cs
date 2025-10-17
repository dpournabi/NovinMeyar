using System;

namespace NovinMeyar.Finance.Domain.Response
{
    public class PaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string MaskedCardNumber { get; set; }
        public string HashedCardNumber { get; set; }
        public string ShaparakRefNumber { get; set; }
        public long? SourceId { get; set; }
        public Guid? PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
