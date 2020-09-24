using System;
using Serilog;
using System.IO;
using Serilog.Events;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Helpers;
using Microsoft.Extensions.Configuration;
using BelezaNaWeb.Framework.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.Api
{
    public class Program
    {
        #region Public Static Methods

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting hosting");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<ApiContext>();

                    DbGeneratorHelper.Create(services);
                }

                host.Run();
            }
            catch (Exception ex) { Log.Fatal(ex, "Host terminated unexpectedly"); }
            finally { Log.CloseAndFlush(); }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
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

        #endregion
    }
}
