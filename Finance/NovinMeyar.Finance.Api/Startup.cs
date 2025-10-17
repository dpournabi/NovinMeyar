using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovinMeyar.Common;
using NovinMeyar.Finance.Api.Data;
using NovinMeyar.Finance.Api.Helper;
using NovinMeyar.Finance.DataLayer;

namespace NovinMeyar.Finance.Api
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
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NovinMeyar.Finance.Api v1"));
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(x => x.WithOrigins(appSettings.CORSTrustedOrigins));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=PaymentBack}/{action=Index}");
                endpoints.MapControllerRoute(name: "payback", pattern: "{controller=PaymentBack}/{action=VerifyTransaction}");
            });

        }
    }
}
