using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Projeto.Produtos.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, string apiName)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = apiName });
                AddTokenSuport(setup);
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, string apiName)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
            });
        }

        private static void AddTokenSuport(SwaggerGenOptions setup)
        {
            var securityDefinition = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            };

            setup.AddSecurityDefinition("Bearer", securityDefinition);

            var security = new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                    }
                };

            setup.AddSecurityRequirement(security);
        }
    }
}
