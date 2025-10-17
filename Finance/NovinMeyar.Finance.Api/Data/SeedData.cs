using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Finance.DataLayer;
using System.Threading.Tasks;

namespace NovinMeyar.Finance.Api.Data
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
    }
}
