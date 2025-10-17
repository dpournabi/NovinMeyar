namespace NovinMeyar.Technical.Domain.Requests
{
    public class VerifyRequestModel
    {
        public string InvoiceDate { get; set; }
        public long InvoiceNumber { get; set; }
        public string TransactionReferenceID { get; set; }
    }
}
