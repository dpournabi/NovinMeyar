using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Common;

namespace NovinMeyar.Technical.Api.Helper
{
    public class Cors
    {
        public static void Enable(IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = AppSettings.Instance(services, configuration);
            services.AddCors(options =>
                options.AddPolicy(name: Constants.CorsName,
                    builder =>
                    {
                        builder
                        //.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(appSetting.CORSTrustedOrigins);
                    })
                );
        }
    }
}
