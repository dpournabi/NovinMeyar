using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace NovinMeyar.Common
{
    public class AppSettings
    {
        private static volatile AppSettings _instance;
        private static object lockObject = new object();
        public static AppSettings Instance(IServiceCollection services, IConfiguration configuration)
        {
            if (_instance is null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        services.Configure<AppSettings>(configuration);
                        _instance = configuration.Get<AppSettings>();
                    }
                }
            }
            return _instance;
        }
        public decimal? TravelExpenses { get; set; }
        public int? Tax { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public SerilogSetting Serilog { get; set; }
        public string IdentityServerAddress { get; set; }
        public QueueSettings QueueSettings { get; set; }
        public string[] CORSTrustedOrigins { get; set; }
        public string Admin { get; set; }
        public bool TestMode { get; set; }
    }
    public class ConnectionStrings
    {
        public string MSSQL { get; set; }
    }
    public class EmailSettings
    {
        public string SmtpAddress { get; set; }
        public int PortNumber { get; set; }
        public bool EnableSSL { get; set; }
        public string EmailFromAddress { get; set; }
        public string Password { get; set; }
        public string EmailToAddress { get; set; }
    }
    public class Override
    {
        public string Microsoft { get; set; }
        public string System { get; set; }
    }
    public class MinimumLevel
    {
        public string Default { get; set; }
        public Override Override { get; set; }
    }
    public class SerilogSetting
    {
        public MinimumLevel MinimumLevel { get; set; }
        public List<string> Enrich { get; set; }
        public string LogFileName { get; set; }
    }
    public class QueueSettings
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
