using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovinMeyar.Technical.Api.Helper;
using NovinMeyar.Technical.Api.Data;
using NovinMeyar.Technical.DataLayer;
using NovinMeyar.Common;
using Microsoft.AspNetCore.Rewrite;

namespace NovinMeyar.Technical.Api
{
    public class Startup
    {
        private static AppSettings appSettings;
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration);
            appSettings = configuration.Get<AppSettings>();

            services.AddControllersWithViews();
            services.AddMvc();
            ServiceConfigurations.ConfigureSwagger(services);
            ServiceConfigurations.ConfigureDatabase(services, configuration);
            ServiceConfigurations.ConfigureVersioning(services);
            ServiceConfigurations.ConfigureApiProtect(services, configuration);
            ServiceConfigurations.ConfigureLogger(services, configuration);
            Cors.Enable(services, configuration);
            ServiceConfigurations.ConfigureMassTransit(services, configuration);
            ServiceConfigurations.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
            var seedData = new SeedData(dataContext);
#if DEBUG
            if (env.IsDevelopment())
            {
                //seedData.CreateDatabases(app).Wait();
            }
#endif
            seedData.SeedLatestCertificateTypeAsync().Wait();
            seedData.SeedBalanceWeightAntiShockTypeAsync().Wait();
            seedData.SeedBalanceWeightTypeAsync().Wait();
            seedData.SeedBrakeTypeAsync().Wait();
            seedData.SeedCabinAntiShockTypeAsync().Wait();
            seedData.SeedDoorTypeAsync().Wait();
            seedData.SeedElevatorTypeAsync().Wait();
            seedData.SeedLocationTypeAsync().Wait();
            seedData.SeedShoesTypeAsync().Wait();
            seedData.SeedInspectionTypeAsync().Wait();
            seedData.SeedInstallationCompanyAsync().Wait();
            seedData.SeedWallMaterialTypeAsync().Wait();
            seedData.SeedBedMaterialTypeAsync().Wait();
            seedData.SeedPulleyMaterialTypeAsync().Wait();
            seedData.SeedInspectionTariffsAsync().Wait();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NovinMeyar.Technical.Api v1"));
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(x => x.WithOrigins(appSettings.CORSTrustedOrigins));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "payment", pattern: "{controller=Payment}/{action=PrePaymentView}");
            });
        }
    }
}
