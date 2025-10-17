using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.DTO;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Services.ver_1._0
{
    public interface ICompleteRegisrationRequestService
    {
        //Task<ResponseModel> CompleteAsync(TechnicalInformationModel model, string userName, long branchId, string branchCode);
        Task<ResponseModel<TechnicalInformationModel>> GetAsync(long Id);
    }
}
