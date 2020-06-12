using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using BelezaNaWebAPI.Filters;
using BelezaNaWebAPI.Modules;
using System.IO;

namespace BelezaNaWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Startup.Configuration = configuration;

            var envPath = Path.Combine(env.ContentRootPath, ".env");
            if (File.Exists(envPath))
            {
                DotNetEnv.Env.Load();
            }

            JsonConvert.DefaultSettings = () =>
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
#if DEBUG
                    Formatting = Formatting.Indented
#else
                    Formatting = Formatting.None
#endif
                };
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<IUrlHelper>(x => x
                    .GetRequiredService<IUrlHelperFactory>()
                    .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext))
                .AddMvcCore(options =>
                {
                    options.Filters.Add(new ValidateModelFilter());
                    options.Filters.Add(new CacheControlFilter());
                })
                .AddApiExplorer()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services
                .AddAutoMapper(typeof(Startup))
                .AddSwagger();

            services.AddRouting();
            services.AddControllers();
            services.AddHealthChecks();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DefaultModule>();
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        public void ConfigureProductionContainer(ContainerBuilder builder)
        {
            ConfigureContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler();

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app
                .UseOptionsVerbHandler()
                .UseSwaggerWithOptions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecks(Constants.Health.EndPoint);
            });

            logger.LogInformation("Server configuration is completed");
        }
    }
}
