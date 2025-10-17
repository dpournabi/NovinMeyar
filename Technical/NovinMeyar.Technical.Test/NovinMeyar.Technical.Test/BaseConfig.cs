using System;
using Serilog;
using MassTransit;
using NUnit.Framework;
using RabbitMQ.Client;
using NovinMeyar.Technical.Api;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Technical.DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Api.Services.ver_1._0.Implementation;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Common;

namespace NovinMeyar.Technical.Test
{
    public class BaseConfig
    {
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }
        public IBaseInformationService BaseInformationService { get; set; }
        public ICompleteRegisrationRequestService CompleteRegisrationRequestService { get; set; }
        public IElevatorInspectionService ElevatorInspectionService { get; set; }
        public IFastRegisrationRequestService FastRegisrationRequestService { get; set; }
        public IInstallatinCompanyService InstallatinCompanyService { get; set; }

        [SetUp]
        public void Init()
        {
            var services = new ServiceCollection();
            var appSetting = Configuration.Get<AppSettings>();

            #region Config Masstransit

            services.AddMassTransit(c =>
            {
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(appSetting.QueueSettings.HostName, appSetting.QueueSettings.VirtualHost, h => {
                        h.Username(appSetting.QueueSettings.UserName);
                        h.Password(appSetting.QueueSettings.Password);
                    });

                    cfg.ExchangeType = ExchangeType.Direct;
                });

                c.AddRequestClient<RequestRegistrationBroker>();
                c.AddRequestClient<StreamBroker>();
            });
            services.AddSingleton<IPublishEndpoint>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(p => p.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(p => p.GetRequiredService<IBusControl>());
            services.AddMassTransitHostedService();

            #endregion

            #region Config Serilog
            
            services.AddSingleton<ILogger>(f =>
            {
                var logConf = new Serilog.LoggerConfiguration()
                    .ReadFrom.Configuration(Configuration)
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
            #endregion

            #region Config DataContext

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sqlserverOptions =>
                {
                    sqlserverOptions.CommandTimeout(360); // 3 minutes
                    sqlserverOptions.EnableRetryOnFailure(3);
                    sqlserverOptions.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
                });

                options.EnableDetailedErrors(true);
            }, ServiceLifetime.Transient);
            #endregion

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IBaseInformationService, BaseInformationService>();
            services.AddScoped<ICompleteRegisrationRequestService, CompleteRegisrationRequestService>();
            services.AddScoped<IElevatorInspectionService, ElevatorInspectionService>();
            services.AddScoped<IFastRegisrationRequestService, FastRegisrationRequestService>();
            services.AddScoped<IInstallatinCompanyService, InstallatinCompanyService>();
            
            var serviceProvider = services.BuildServiceProvider();
            BaseInformationService = serviceProvider.GetService<IBaseInformationService>();
            CompleteRegisrationRequestService = serviceProvider.GetService<ICompleteRegisrationRequestService>();
            ElevatorInspectionService = serviceProvider.GetService<IElevatorInspectionService>();
            FastRegisrationRequestService = serviceProvider.GetService<IFastRegisrationRequestService>();
            InstallatinCompanyService = serviceProvider.GetService<IInstallatinCompanyService>();
        }
    }
}
