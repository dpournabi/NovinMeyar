using System;

namespace NovinMeyar.Common.MessageBrokers
{
    public class GetPaymentTokenBroker
    {
        public long InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public string CreatorUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Tag { get; set; }
        public string SourceTable { get; set; }
        public string SourceKey { get; set; }
        public string DataFlag { get; set; }
    }
}
