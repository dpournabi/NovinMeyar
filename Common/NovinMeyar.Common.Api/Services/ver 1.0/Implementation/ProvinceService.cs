using System.Threading.Tasks;
using NovinMeyar.Common.DataLayer;
using NovinMeyar.FileManagment.Api.Services.ver_1._0;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common.Domain;
using NovinMeyar.Common.Domain.Entities;

namespace NovinMeyar.Common.Api.Services.ver_1._0.Implementation
{
    public class ProvinceService : IProvinceService
    {
        private readonly DataContext dataContext;
        public ProvinceService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ResponseModel<Province>> GetProvincesAsync(SearchProvince search)
        {
            var response = new ResponseModel<Province> { Succeed = false };
            var data = await (from p in dataContext.Provinces
                         where (search.Name==null || p.Name.Contains(search.Name)) &&
                               (!search.ProvinceId.HasValue || p.Id==search.ProvinceId.Value)
                        select p).ToListAsync();
            response.Succeed = true;
            response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            response.ResponseList = data;
            return response;
        }

        public async Task<ResponseModel<City>> GetCitiesAsync(SearchCity search)
        {
            var response = new ResponseModel<City> { Succeed = false };
            var data = await(from c in dataContext.Cities
                             where c.ProvinceId == search.ProvinceId &&
                                   (search.Name == null || c.Name.Contains(search.Name)) &&
                                   (!search.CityId.HasValue || c.Id == search.CityId.Value)
                             select c).ToListAsync();
            response.Succeed = true;
            response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            response.ResponseList = data;
            return response;
        }
    }
}
