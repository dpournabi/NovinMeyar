using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using MassTransit;
using RabbitMQ.Client;
using NovinMeyar.Notification.Api.Services;
using NovinMeyar.Notification.Api.Services.Implementation;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Notification.Api.MessageBroker;

namespace NovinMeyar.Notification.Api.Helper
{
    public class ServiceConfigurations
    {
        public static AppSettings appSetting;
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovinMeyar.Notification", Version = "v1" });
            });
        }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
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
        public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
        {
            appSetting = configuration.Get<AppSettings>();
            services.AddMassTransit(c =>
            {
                c.AddConsumer<VerificationCodeConsumer>();
                c.AddConsumer<CustomMessageConsumer>();
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("sending-verification-code-consumer", e =>
                    {
                        e.ConfigureConsumer<VerificationCodeConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("sending-custom-message-consumer", e =>
                    {
                        e.ConfigureConsumer<CustomMessageConsumer>(context);
                    });

                    cfg.Host(appSetting.QueueSettings.HostName, appSetting.QueueSettings.VirtualHost, h => {
                        h.Username(appSetting.QueueSettings.UserName);
                        h.Password(appSetting.QueueSettings.Password);
                    });

                    cfg.ExchangeType = ExchangeType.Direct;
                });
            });
            services.AddSingleton<IPublishEndpoint>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(p => p.GetRequiredService<IBusControl>());
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
                jwt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });
        }
    }
}
