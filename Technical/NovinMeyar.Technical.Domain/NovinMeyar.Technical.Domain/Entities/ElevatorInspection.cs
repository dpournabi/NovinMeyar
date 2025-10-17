using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common;
using System;

namespace NovinMeyar.Technical.Domain.Entities
{
    [Index(nameof(ElevatorInformationId), nameof(Row))]
    public class ElevatorInspection: BaseEntity
    {
        public Guid Tag { get; set; }
        public int Row { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset? InspectionDate { get; set; }
        public TimeSpan? InspectionTime { get; set; }
        public Guid? PaymentId { get; set; }
        public string InvoiceDate { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public long ElevatorInformationId { get; set; }
    }
}
