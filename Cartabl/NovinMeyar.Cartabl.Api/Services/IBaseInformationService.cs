using NovinMeyar.Cartabl.Api.Models;
using NovinMeyar.Cartabl.Domain.CommentModels;
using NovinMeyar.Cartabl.Domain.Entities;
using NovinMeyar.Cartabl.Domain.SearchModels;
using NovinMeyar.Common;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.Services.ver_1._0
{
    public interface IBaseInformationService
    {
        Task<ResponseModel<RequestType>> GetRequestTypesAsync();
        Task<ResponseModel<RequestVM>> SearchRequestAsync(RequestSearch  search, long branchId, bool currentRoleIsAdmin, string userName, string currentRoleName);
        Task<ResponseModel> SeenRequestAsync(string id);
        Task<ResponseModel<RequestType>> RequestTypesPagedAsync(RequestTypesSearch requestTypesSearch);
        Task<ResponseModel> ConfirmationAsync(string id,string currentUserRole);
        Task<ResponseModel> RejectAsync(string id,string currentUserRole);
        Task<ResponseModel> CreateCommentAsync(string id, string name, RequestComment model);
        Task<ResponseModel<object>> GetCommentsAsync(string id);
        Task<ResponseModel> UndoRequestStateAsync(long id);
    }
}
