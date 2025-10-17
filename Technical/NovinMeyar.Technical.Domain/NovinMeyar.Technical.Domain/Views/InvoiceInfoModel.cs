namespace NovinMeyar.Technical.Domain.Views
{
    public class InvoiceInfoModel
    {
        public string ResponsibleFullName { get; set; }
        public string ResponsibleCell { get; set; }
        public string Address { get; set; }
        public string DocumentNumber { get; set; }
        public int Row { get; set; }
        public long InvoiceNumber { get; set; }
        public string InstallationCompanyName { get; set; }
        public string Amount { get; set; }
        public string TravelExpenses { get; set; }
        public int AdditionalStopCount { get; set; }
        public string AdditionalPayment { get; set; }
        public string Tax { get; set; }
        public string Date { get; set; }
        public string TotalPayment { get; set; }
        public string SourceTable { get; set; }
        public string SourceKey { get; set; }
    }
}
