using System;

namespace NovinMeyar.Technical.Domain.Views
{
    public class ElevatorInspectionViewModel
    {
        public long Id { get; set; }
        public string InspectionType { get; set; }
        public int StopCount { get; set; }
        public int Step { get; set; }
        public int Row { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset? InspectionDate { get; set; }
        public Guid? PaymentId { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public string InspectionTime { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string PaymentIdentity { get; set; }
        public string ResponsibleCell { get; set; }
        public Guid Tag { get; set; }
    }
}
