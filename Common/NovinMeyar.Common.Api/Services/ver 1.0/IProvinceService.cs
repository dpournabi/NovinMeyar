using NovinMeyar.Common;
using NovinMeyar.Common.Domain;
using NovinMeyar.Common.Domain.Entities;
using System.Threading.Tasks;

namespace NovinMeyar.FileManagment.Api.Services.ver_1._0
{
    public interface IProvinceService
    {
        Task<ResponseModel<Province>> GetProvincesAsync(SearchProvince search);
        Task<ResponseModel<City>> GetCitiesAsync(SearchCity search);
    }
}
