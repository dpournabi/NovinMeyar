using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovinMeyar.Common;
using NovinMeyar.Notification.Api.Helper;

namespace NovinMeyar.Notification.Api
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

            services.AddControllers();
            ServiceConfigurations.ConfigureSwagger(services);
            //ServiceConfigurations.ConfigureDatabase(services, configuration);
            ServiceConfigurations.ConfigureVersioning(services);
            ServiceConfigurations.ConfigureApiProtect(services, configuration);
            ServiceConfigurations.ConfigureLogger(services, configuration);
            ServiceConfigurations.ConfigureMassTransit(services, configuration);
            ServiceConfigurations.RegisterServices(services);
            Cors.Enable(services, configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //using var serviceScope = app.ApplicationServices.CreateScope();
            //var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
           // var seedData = new SeedData(dataContext);
            //seedData.CreateDatabases(app).Wait();


            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NovinMeyar.FileManagment.Api v1"));
            app.UseRouting();
            app.UseCors(x => x.WithOrigins(appSettings.CORSTrustedOrigins));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
