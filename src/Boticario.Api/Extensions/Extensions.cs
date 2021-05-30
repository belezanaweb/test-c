using Boticario.ApplicationService.IServices;
using Boticario.ApplicationService.Services;
using Boticario.Domain.Handlers;
using Boticario.Repository;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Linq;

namespace Boticario.Api
{
    public static class Extensions
    {

        public static void AddRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddScoped<INotification, NotificatorHandler>();
            services.AddScoped<IProductsService, ProductsService>();
            //Singleton para continuar na memoria
            services.AddSingleton<IProductsRepository, ProductsRepository>();
        }

        public static void AddTelemetry(this IServiceCollection services, string key)
        {
            services.AddApplicationInsightsTelemetry();
            services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>(
                (module, o) => {
                    module.EnableSqlCommandTextInstrumentation = true;
                }
            );
        }


        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Boticario.Api", Version = "v1", });
                



                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Bearer {{access_token}}",
                    In = ParameterLocation.Header,
                    Name = "Authorization"
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                var allDocumentation = Directory.GetFiles(basePath, "*.xml", SearchOption.AllDirectories).Distinct().ToList();

                for (int i = 0; i < allDocumentation.Count; i++)
                {
                    c.IncludeXmlComments(allDocumentation[i]);
                }

                var defaultPath = Path.Combine(basePath, "XmlDocument.xml");

                if (File.Exists(defaultPath))
                    c.IncludeXmlComments(defaultPath);

                // if (enumAsString)
                //    c.DescribeAllEnumsAsStrings();
            });
        }


        public static void AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
            });
        }

    }
}
