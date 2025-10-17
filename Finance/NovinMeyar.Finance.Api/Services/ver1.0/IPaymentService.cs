using NovinMeyar.Common;
using NovinMeyar.Finance.Domain.DTO;
using NovinMeyar.Finance.Domain.Entities;
using NovinMeyar.Finance.Domain.Response;
using System.Threading.Tasks;

namespace NovinMeyar.Finance.Api.Services.ver_1._0
{
    public interface IPaymentService
    {
        Task<ResponseModel> GetTokenAsync(PaymentRequestModel model);
        Task<PaymentResponse> VerifyTransactionResultAsync(string tref, long invoiceNumber, string invoiceDate);
        Task<PaymentHistory> GetPaymentHistoryAsync(long invoiceNumber);
        Task<ResponseModel> SavePaymentInformation(PaymentHistory payment);
    }
}
