using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.DTO;
using NovinMeyar.Technical.Domain.Views;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Services.ver_1._0
{
    public interface IFastRegisrationRequestService 
    {
        Task<ResponseModel> GetDisplayInvoiceAsync(Guid tag);
        Task<ResponseModel> PrepareToPayAsync(Guid tag, string userName, CancellationToken cancellationToken);
        Task<ResponseModel> SaveAsync(FastRegistrationModel model, string userName, long branchId, string branchCode, string branchName, string currentRoleName, bool currentRoleIsAdmin);
        Task<ResponseModel> UpdateTechnicalInformationAsync(TechnicalInformationModel model, string userName);
        Task<ResponseModel<VMFastRegistration>> SearchAsync(FastRegistrationSearch search, long branchId, bool currentRoleIsAdmin, string currentUserRole, string userName);
        Task<ResponseModel> DeactiveAsync(long id, string userName);
        Task<ResponseModel> LockRequest(long Id, string userName);
        Task<ResponseModel<string>> GetDocumentCategoriesAsync(string currentRole);
        Task<ResponseModel<string>> GetDocumentsAsync(string currentRole, string folderName);
        Task<ResponseModel> DownloadFileAsync(string currentRole, string folderName, string fileName);
    }
}
