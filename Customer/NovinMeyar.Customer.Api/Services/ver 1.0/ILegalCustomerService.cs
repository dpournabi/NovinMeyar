using NovinMeyar.Common;
using NovinMeyar.Customer.Domain;
using NovinMeyar.Customer.Domain.Entities;
using System.Threading.Tasks;

namespace NovinMeyar.Customer.Api.Services.ver_1._0
{
    public interface ILegalCustomerService
    {
        Task<ResponseModel> SaveAsync(LegalCustomer customer, long branchId, string userName);
        Task<ResponseModel> DeactiveAsync(long customerId, string userName);
        Task<ResponseModel<LegalCustomer>> SearchAsync(LegalSearch search, long branchId, bool currentRoleIsAdmin, string userName, string currentRoleName);
    }
}
