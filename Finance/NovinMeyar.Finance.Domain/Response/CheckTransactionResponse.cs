namespace NovinMeyar.Finance.Domain.Response
{
    public class CheckTransactionResponse
    {
        public bool Result { get; set; }
        public int Action { get; set; }
        public string TransactionReferenceID { get; set; }
        public long InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int MerchantCode { get; set; }
        public int TerminalCode { get; set; }
        public decimal Amount { get; set; }
        public int TraceNumber { get; set; }
        public long ReferenceNumber { get; set; }
        public string TransactionDate { get; set; }
    }
}
