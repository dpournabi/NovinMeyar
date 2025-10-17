using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Finance.Domain.DTO
{
    public class VerifyRequestModel : BasePaymentInput
    {
        public string InvoiceDate { get; set; }
        public long InvoiceNumber { get; set; }
        public string TransactionReferenceID { get; set; }

        public static implicit operator VerifyRequestModel(VerifyTransactionBroker verifyTransactionBroker)
        {
            return new VerifyRequestModel
            {
                InvoiceDate = verifyTransactionBroker.InvoiceDate,
                InvoiceNumber = verifyTransactionBroker.InvoiceNumber,
                TransactionReferenceID = verifyTransactionBroker.TransactionReferenceID
            };
        }
    }

    
}
