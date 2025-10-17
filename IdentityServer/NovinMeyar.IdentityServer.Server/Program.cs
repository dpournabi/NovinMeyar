using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;

namespace NovinMeyar.IdentityServer.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\Logs\log.txt";
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               //.WriteTo.File(path)
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
                               opts.Listen(IPAddress.Any, port: 5000);
                           });
                           webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                           webBuilder.UseIISIntegration();
                           webBuilder.UseStartup<Startup>();
                       });
        }
    }
}
