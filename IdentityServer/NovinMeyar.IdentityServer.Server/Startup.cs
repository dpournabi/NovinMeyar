using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Api.Helper;

namespace NovinMeyar.IdentityServer.Server
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
            services.AddControllers();
            services.AddApiVersioning();
            services.AddCors();

            //Configurations...
            ServiceConfigurations.ConfigureSwagger(services);
            ServiceConfigurations.ConfigureDatabase(services, configuration);
            ServiceConfigurations.ConfigureIdentity(services, configuration);
            ServiceConfigurations.ConfigureVersioning(services);
            ServiceConfigurations.ConfigureMassTransit(services, configuration);
            ServiceConfigurations.RegisterServices(services);
            ServiceConfigurations.ConfigureLogger(services, configuration);
            ServiceConfigurations.EnableCors(services, configuration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            if (env.IsDevelopment())
            {
                //ServiceConfigurations.MigrateDatabase(app);
            }
#endif
            appSettings = configuration.Get<AppSettings>();
            new ServiceConfigurations().SeedDefaultData(app, configuration);
            app.UseIdentityServer();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NovinMeyar.IdentityServer.Server v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x=>x.WithOrigins(appSettings.CORSTrustedOrigins));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
