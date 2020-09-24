using NSwag;
using AutoMapper;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Globalization;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json.Serialization;
using BelezaNaWeb.Framework.Helpers;
using Microsoft.AspNetCore.Localization;
using BelezaNaWeb.Api.Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;

namespace BelezaNaWeb.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        #region Extension Methods

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(options =>
            {
                options.AllowNullCollections = true;
                options.AllowNullDestinationValues = true;
                options.AddMaps(Assembly.GetExecutingAssembly());
            });

            services.AddSingleton(config.CreateMapper());

            return services;
        }

        public static IServiceCollection ConfigureCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCaching();

            return services;
        }

        public static IServiceCollection ConfigureCulture(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                options.RequestCultureProviders.Clear();
            });

            return services;
        }

        public static IServiceCollection ConfigureCompression(this IServiceCollection services)
        {
            services
                .Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal)
                .Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/png", "image/jpg", "image/jpeg" });
                options.EnableForHttps = true;
            });

            return services;
        }

        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddMvcCore(options =>
                {
                    options.EnableEndpointRouting = true;                 
                })
                .AddDataAnnotations()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.None;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var response = context.ModelState.ToErrorResponse();
                    return new BadRequestObjectResult(response);
                };
            });

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            var availableScopes = new Dictionary<string, string>();

            ConfigHelper.TryGet<SwaggerConfig>(nameof(SwaggerConfig), out var swaggerConfig);            

            services.AddSwaggerDocument(config =>
            {
                config.Title = swaggerConfig.Title;
                config.Version = swaggerConfig.Version;
                config.Description = swaggerConfig.Description;

                config.PostProcess = document =>
                {
                    document.Info.Title = swaggerConfig.Title;
                    document.Info.Version = $"v{swaggerConfig.Version}";
                    document.Info.Description = swaggerConfig.Description;
                    document.Schemes = new OpenApiSchema[] { OpenApiSchema.Https };
                };
            });

            return services;
        }

        public static IServiceCollection ConfigureApiVersion(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
        
        #endregion
    }
}
