using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinMeyar.Finance.Domain.DTO
{
    public class VerifyPeymentModel: BasePaymentInput
    {
        public long InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceDate { get; set; }
        public string Timestamp { get; set; }
    }
}
