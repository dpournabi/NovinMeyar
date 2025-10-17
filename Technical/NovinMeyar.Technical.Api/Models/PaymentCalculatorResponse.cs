namespace NovinMeyar.Technical.Api.Models
{
    public class PaymentCalculatorResponse
    {
        public decimal TaxValue { get; set; }
        public decimal TravelExpenseValue { get; set; }
        public decimal TariffValue { get; set; }
        public decimal AdditionalPayPerStepValue { get; set; }
        public int AddtionalStopCount { get; set; }
        public int Step { get; set; }
        public decimal TotalPaymenyValue { get; set; }
    }
}
