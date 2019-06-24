using BelezanaWeb.Api.Filters;
using BelezanaWeb.IoC;
using BelezanaWeb.Model.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Buffers;
using System.Text;

namespace BelezanaWeb.Api
{
    public class Startup
    {
        public IConfigurationRoot _configuration { get; }
        readonly string MyAllowSpecificOrigins = "myAllowSpecificOrigins";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            AppSettings.Initialize();
            AppSettings.ConnectionString.BelezanaWebDatabase = _configuration["ConnectionStrings:BelezanaWebDatabase"];
            AppSettings.MongoDB.ServerName = _configuration["MongoDB:ServerName"];
            AppSettings.MongoDB.DatabaseName = _configuration["MongoDB:DatabaseName"];
            AppSettings.MongoDB.Collection = _configuration["MongoDB:Collection"];

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ExcetionFilter());
                options.Filters.Add(new LogsRequestsAttribute());
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            });            

            // Injeção de dependência.
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            InjectorContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseMiddleware(typeof(ExceptionFilterMiddleware));


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/v1/{controller}/{id?}"
                    );
            });

            app.UseStaticFiles();
        }
    }
}
