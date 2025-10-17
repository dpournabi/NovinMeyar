using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Cartabl.DataLayer;
using NovinMeyar.Cartabl.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Cartabl.Api.Data
{
    public class SeedData
    {
        private readonly DataContext dataContext;
        public SeedData(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task CreateDatabases(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
            if (dataContext != null && dataContext.Database != null)
            {
                dataContext.Database.Migrate();
            }
        }

        public async Task SeedRequestTypeAsync()
        {
            if (!dataContext.RequestTypes.Any())
            {
                await dataContext.AddRangeAsync(new List<RequestType>
                {
                    new RequestType{  Title = "درخواست بازرسی آسانسور"},
                    new RequestType{  Title = "درخواست بازرسی کالا"},
                });
                await dataContext.SaveChangesAsync();
            }
        }
        public async Task SeedIncpectionTypeAsync()
        {
            if (!dataContext.RequestTypes.Any())
            {
                await dataContext.AddRangeAsync(new List<RequestType>
                {
                    new RequestType{  Title = "درخواست بازرسی اولیه"},
                    new RequestType{  Title = "درخواست بازرسی ادواری"},
                });
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
