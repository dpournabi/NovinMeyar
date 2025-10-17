using System;
using Serilog;
using MassTransit;
using RabbitMQ.Client;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Server.Services;
using IdentityServer4.Services;
using NovinMeyar.IdentityServer.Server.Services.Implementation;
using NovinMeyar.IdentityServer.DataLayer;
using NovinMeyar.IdentityServer.Server;
using NovinMeyar.IdentityServer.Domain.Entities;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using IdentityServer4.EntityFramework.DbContexts;
using NovinMeyar.IdentityServer.Server.Data;
using System.Threading.Tasks;

namespace NovinMeyar.IdentityServer.Api.Helper
{
    public class ServiceConfigurations
    {
        public static AppSettings appSetting;
        public static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = AppSettings.Instance(services, configuration);
            var lockoutOptions = new LockoutOptions()
            {
                AllowedForNewUsers = true,
                DefaultLockoutTimeSpan = TimeSpan.FromDays(1),
                MaxFailedAccessAttempts = 5
            };

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            appSetting = configuration.Get<AppSettings>();

            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sqlserverOptions =>
                {
                    sqlserverOptions.CommandTimeout(360); // 3 minutes
                    sqlserverOptions.EnableRetryOnFailure(3);
                    sqlserverOptions.MigrationsAssembly(migrationsAssembly);
                });
            },ServiceLifetime.Transient);

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Lockout = lockoutOptions;
                options.User = new UserOptions { RequireUniqueEmail = false };
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;

            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";
                options.Authentication = new AuthenticationOptions()
                {
                    CookieLifetime = TimeSpan.FromHours(12), // ID server cookie timeout set to 12 hours
                    CookieSlidingExpiration = true
                };
            })
            .AddDeveloperSigningCredential()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sql => sql.MigrationsAssembly(migrationsAssembly));
                options.EnableTokenCleanup = true;
            })
            .AddAspNetIdentity<ApplicationUser>();

            services.AddAuthentication()
                     .AddJwtBearer(jwt => {
                         jwt.SaveToken = true;
                         jwt.Authority = appSetting.IdentityServerAddress;
                         jwt.RequireHttpsMetadata = false;
                         jwt.Audience = Common.Constants.Scopes.NovinMeyarApi;
                     });
        }
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovinMeyar.IdentityServer.Server", Version = "v1" });
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
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
        public static void ConfigureLogger(IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = AppSettings.Instance(services, configuration);
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
                            TableName = "Logs.IdentityServer.API"
                        });

                return logConf.CreateLogger();
            });
        }
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = AppSettings.Instance(services, configuration);
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(appSetting.ConnectionStrings.MSSQL, sqlserverOptions =>
                {
                    sqlserverOptions.CommandTimeout(180); // 3 minutes
                    sqlserverOptions.EnableRetryOnFailure(3);
                    sqlserverOptions.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
                });

                options.EnableDetailedErrors(true);
            }, ServiceLifetime.Singleton);
        }
        public static void MigrateDatabase(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            //var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger>();

            Log.Information("Migrating the database...");
            var persistedGrantDbContext = serviceScope.ServiceProvider.GetService<PersistedGrantDbContext>();
            if (persistedGrantDbContext != null && persistedGrantDbContext.Database != null)
            {
                persistedGrantDbContext.Database.Migrate();
            }

            var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (applicationDbContext != null && applicationDbContext.Database != null)
            {
                applicationDbContext.Database.Migrate();
            }

            var configurationDbContext = serviceScope.ServiceProvider.GetService<ConfigurationDbContext>();
            if (configurationDbContext != null && configurationDbContext.Database != null)
            {
                configurationDbContext.Database.Migrate();
            }
        }
        public void SeedDefaultData(IApplicationBuilder app, IConfiguration configuration)
        {
            var seedData = new SeedData(app, configuration);
            seedData.SeedDefaultData();
        }
        public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.Get<AppSettings>();
            services.AddMassTransit(c =>
            {
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(appSettings.QueueSettings.HostName, appSettings.QueueSettings.VirtualHost, h =>
                    {
                        h.Username(appSettings.QueueSettings.UserName);
                        h.Password(appSettings.QueueSettings.Password);
                    });

                    cfg.ExchangeType = ExchangeType.Direct;
                });
                c.AddRequestClient<InstallatinCompanyBroker>();
                c.AddRequestClient<RemoveInstallationCompanyBroker>();
                c.AddRequestClient<VerificationCodeBroker>();
                c.AddRequestClient<CustomMessageBroker>();
            });

            services.AddMassTransitHostedService();
        }
        public static void EnableCors(IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = AppSettings.Instance(services, configuration);
            services.AddCors(options =>
                options.AddPolicy(name: NovinMeyar.Common.Constants.CorsName,
                    builder =>
                    {
                        builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(appSetting.CORSTrustedOrigins);
                    })
                );
        }
    }
}
