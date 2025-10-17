using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using NovinMeyar.Cartabl.DataLayer;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using RabbitMQ.Client;
using NovinMeyar.Cartabl.Api.MessageBroker;
using NovinMeyar.Cartabl.Api.Services;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Common;
using NovinMeyar.Cartabl.Api.Services.ver_1._0;
using NovinMeyar.Cartabl.Api.Services.ver_1._0.Implementation;
using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Cartabl.Api.Helper
{
    public class ServiceConfigurations
    {
        public static AppSettings appSetting;
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovinMeyar.Cartabl.Api", Version = "v1" });
            });
        }
        public static void ConfigureVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(config => 
            {
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options => 
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IBaseInformationService, BaseInformationService>();

        }
        public static void ConfigureLogger(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddSingleton<ILogger>(f =>
            {
                var logConf = new Serilog.LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .Enrich.FromLogContext()
                    .Enrich.WithCorrelationId()
                    .WriteTo.File(appSetting.Serilog.LogFileName,
                                  restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                                  flushToDiskInterval: TimeSpan.FromMinutes(1),
                                  rollOnFileSizeLimit: true,
                                  encoding: System.Text.Encoding.UTF8,
                                  outputTemplate: "{NewLine}{Timestamp:yyyy/MM/dd HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                    .WriteTo.MSSqlServer(connectionString: appSetting.ConnectionStrings.MSSQL,
                        sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                        {
                            AutoCreateSqlTable = true,
                            TableName = "Logs"
                        });

                return logConf.CreateLogger();
            });
        }
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sqlserverOptions =>
                {
                    sqlserverOptions.CommandTimeout(180); // 3 minutes
                    sqlserverOptions.EnableRetryOnFailure(3);
                    sqlserverOptions.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
                });

                options.EnableDetailedErrors(true);
            });
        }
        public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddMassTransit(c =>
            {
                c.AddConsumer<RequestConsumer>();
                c.AddConsumer<UpdateRequestConsumer>();
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("request-consumer-queue", e =>
                    {
                        e.ConfigureConsumer<RequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint("update-request-consumer-queue", e =>
                    {
                        e.ConfigureConsumer<UpdateRequestConsumer>(context);
                    });

                    cfg.Host(appSetting.QueueSettings.HostName, appSetting.QueueSettings.VirtualHost, h => {
                        h.Username(appSetting.QueueSettings.UserName);
                        h.Password(appSetting.QueueSettings.Password);
                    });
                    cfg.PrefetchCount = 1000;
                    cfg.ExchangeType = ExchangeType.Direct;
                });
                c.AddRequestClient<LockRequestBroker>();
            });

            services.AddMassTransitHostedService();
        }
        public static void ConfigureApiProtect(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "Default challenge scheme";
                options.DefaultForbidScheme = "Default forbiden scheme";
                options.AddScheme<CustomSchemeHandler>("Default forbiden scheme", "Forbiden scheme name");
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.Authority = appSetting.IdentityServerAddress;
                jwt.RequireHttpsMetadata = false;
                jwt.Audience = Common.Constants.Scopes.NovinMeyarApi;
            });
        }
    }
}
