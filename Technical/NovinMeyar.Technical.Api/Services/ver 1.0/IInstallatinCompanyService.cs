using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Services.ver_1._0
{
    public interface IInstallatinCompanyService
    {
        Task<ResponseModel<InstallatinCompany>> SearchAsync(InstallatinCompanySearch search, bool currentRoleIsAdmin, IEnumerable<string> currentBranchUsers, string currentUserRole);
        Task<ResponseModel> RegisterNewAsync(InstallatinCompany installatinCompany, string userName);
        Task<ResponseModel> EditAsync(InstallatinCompany installatinCompany, string userName, int? installationCompanyId);
        Task<ResponseModel> DeactiveAsync(long installatinCompanyId, string userName);
        Task<ResponseModel> PhysicalDeleteAsync(long installatinCompanyId, string userName);
    }
}
