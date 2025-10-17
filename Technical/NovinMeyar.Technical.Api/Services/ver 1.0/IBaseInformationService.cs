using NovinMeyar.Common;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.Views;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Services.ver_1._0
{
    public interface IBaseInformationService
    {
        Task<ResponseModel<ObjectDetail>> SearchAsync(BaseInformationSearch search);
        Task<ResponseModel<Property>> SearchPropertyAsync(SearchProperty search);
        Task<ResponseModel> SaveAsync(ObjectDetail model, string userName);
        Task<ResponseModel> DeactiveAsync(long objectDetailId, string userName);
        Task<ResponseModel> SavePropertyAsync(Property model, string userName);
        Task<ResponseModel> DeletePropertyAsync(long id, string userName);
        Task<ResponseModel<ObjectDetail>> GetTreeAsync();
        Task<ResponseModel<ObjectDetailItem>> GetObjectDetailItemsAsync(long objectDetailId);
        Task<ResponseModel> DeactiveObjectDetailPropertyAsync(long objectDetailPropertyId, string userName);
        Task<ResponseModel<InspectionType>> GetInspectionTypesAsync();
        Task<ResponseModel<LatestCertificateType>> GetLatestCertificateTypesAsync();
        Task<ResponseModel<ElevatorType>> GetElevatorTypesAsync();
        Task<ResponseModel<BrakeType>> GetBrakeTypesAsync();
        Task<ResponseModel<CabinAntiShockType>> GetCabinAntiShockTypesAsync();
        Task<ResponseModel<CounterWeightAntiShockType>> GetCounterWeightAntiShockTypesAsync();
        Task<ResponseModel<CounterWeightType>> GetCounterWeightTypesAsync();
        Task<ResponseModel<DoorType>> GetDoorTypesAsync(bool isCabin);
        Task<ResponseModel<InstallationType>> GetInstallationTypesAsync();
        Task<ResponseModel<LocationType>> GetLocationTypesAsync(byte LocationEnum);
        Task<ResponseModel> FindLocationTypeAsync(string title);
        Task<ResponseModel<ShoesType>> GetWeightShoesTypesAsync();
    }
}
