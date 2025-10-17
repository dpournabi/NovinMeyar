using NovinMeyar.Common;
using NovinMeyar.FileManagment.Domain;
using System.Threading.Tasks;

namespace NovinMeyar.FileManagment.Api.Services.ver_1._0
{
    public interface IFileManagmentService
    {
        Task<ResponseModel> SaveStreamAsync(IFileStream stream, string userName);
        Task<ResponseModel> DeleteStreamAsync(long streamId, string userName, string roleName);
        Task<ResponseModel> GetStreamAsync(long id);
        Task<ResponseModel> GenerateDownloadKeyAsync(long id, string userName);
        Task<ResponseModel> GetLargeStreamAsync(string cipherKey);
    }
}
