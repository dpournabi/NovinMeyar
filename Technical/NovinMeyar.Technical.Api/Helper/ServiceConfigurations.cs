using System;
using Serilog;
using MassTransit;
using RabbitMQ.Client;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Technical.DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Api.Services.ver_1._0.Implementation;
using NovinMeyar.Technical.Api.MessageBroker;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Common;

namespace NovinMeyar.Technical.Api.Helper
{
    public class ServiceConfigurations
    {
        public static AppSettings appSetting;
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovinMeyar.Technical.Server", Version = "v1" });
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
            services.AddScoped<IFastRegisrationRequestService, FastRegisrationRequestService>();
            services.AddScoped<IInstallatinCompanyService, InstallatinCompanyService>();
            services.AddScoped<IBaseInformationService, BaseInformationService>();
            services.AddScoped<IElevatorInspectionService, ElevatorInspectionService>();
            services.AddScoped<IPaymentCalculator, PaymentCalculator>();
        }
        public static void ConfigureLogger(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddSingleton<ILogger>(f =>
            {
                var logConf = new Serilog.LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .Enrich.FromLogContext()
                    .Enrich
                    .WithCorrelationId()
                    .WriteTo.Console()
                    .WriteTo.File(appSetting.Serilog.LogFileName,
                                  restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
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
                    sqlserverOptions.CommandTimeout(360); // 3 minutes
                    sqlserverOptions.EnableRetryOnFailure(3);
                    sqlserverOptions.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
                });

                options.EnableDetailedErrors(true);
            }, ServiceLifetime.Scoped);
        }
        public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddMassTransit(c =>
            {
                c.AddConsumer<AddInstallationCompanyConsumer>();
                c.AddConsumer<UndoAddInstallationCompanyConsumer>();
                c.AddConsumer<UpdatePaymentStatusConsumer>();
                c.AddConsumer<LockRequestConsumer>();
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("add-installation-company-consumer", e =>
                    {
                        e.ConfigureConsumer<AddInstallationCompanyConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("lock-request-consumer", e =>
                    {
                        e.ConfigureConsumer<LockRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("undo-add-installation-company-consumer", e =>
                    {
                        e.ConfigureConsumer<UndoAddInstallationCompanyConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("update-payment-status-consumer", e =>
                    {
                        e.ConfigureConsumer<UpdatePaymentStatusConsumer>(context);
                    });

                    cfg.Host(appSetting.QueueSettings.HostName, appSetting.QueueSettings.VirtualHost, h => {
                        h.Username(appSetting.QueueSettings.UserName);
                        h.Password(appSetting.QueueSettings.Password);
                    });

                    cfg.ExchangeType = ExchangeType.Direct;
                });
                c.AddRequestClient<UpdateRequestBroker>();
                c.AddRequestClient<RequestRegistrationBroker>();
                c.AddRequestClient<GetPaymentTokenBroker>();
                c.AddRequestClient<StreamBroker>();
                c.AddRequestClient<CustomMessageBroker>();
            });
            services.AddSingleton<IPublishEndpoint>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(p => p.GetRequiredService<IBusControl>());
            services.AddMassTransitHostedService();
        }
        public static void ConfigureApiProtect(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddAuthentication(options=>
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
                jwt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });
        }
    }
}
