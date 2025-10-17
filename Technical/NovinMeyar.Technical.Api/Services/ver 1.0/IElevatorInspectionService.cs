using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.DTO;
using NovinMeyar.Technical.Domain.Views;
using System;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Services.ver_1._0
{
    public interface IElevatorInspectionService
    {
        Task<ResponseModel> FindAsync(long key);
        Task<ResponseModel> FindAsync(Guid key);
        Task<ResponseModel<ElevatorInspectionViewModel>> GetAsync(long elevatorInformationId);
        Task<ResponseModel> SaveAsync(ElevatorInspectionModel model, string userName);
        Task<ResponseModel> DeactiveAsync(long id, string userName);
        Task<ResponseModel> NotifyAsync(NotifyModel notifyModel);
        Task<ResponseModel> UpdatePaymentStateAsync(long elevatorInspectionId, Guid? paymentId, DateTimeOffset? paymentDate);
    }
}
