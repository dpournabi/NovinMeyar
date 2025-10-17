using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Net;

namespace NovinMeyar.FileManagment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddCommandLine(args)
                            .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                            .Build();
            return Host.CreateDefaultBuilder(args)
                       .UseSerilog()
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseConfiguration(config);
                           webBuilder.UseKestrel(
                          opts =>
                          {
                              opts.Listen(IPAddress.Any, port: 5003);
                              opts.Limits.MaxRequestBodySize = 20 * 1024 * 1024;//20Mb
                          });
                           webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                           webBuilder.UseIISIntegration();
                           webBuilder.UseStartup<Startup>();
                       });
        }
    }
}
