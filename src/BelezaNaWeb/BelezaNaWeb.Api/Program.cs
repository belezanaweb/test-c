using Serilog;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace BelezaNaWeb.Api
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddCommandLine(args)
                        .AddEnvironmentVariables()
                        .Build();
                })
                .ConfigureLogging((ctx, logging) =>
                {
                    logging
                        .AddConfiguration(ctx.Configuration.GetSection("Logging"))
                        .AddDebug()
                        .AddConsole()
                        .AddSerilog()
                        .AddEventSourceLogger();
                })
                .UseSerilog((ctx, config) =>
                {
                    config
                        .ReadFrom.Configuration(ctx.Configuration)
                        .WriteTo.Debug()
                        .WriteTo.Console();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseStartup<Startup>();
                });
    }
}
