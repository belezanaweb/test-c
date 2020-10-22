using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace belezanaweb.WebApi.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Beleza na Web API",
                        Version = "v1",
                        Description = "API REST criada para o desafio da beleza na web",
                        Contact = new OpenApiContact
                        {
                            Name = "Rafael Baptista",
                            Url = new Uri("https://github.com/rafbaptista")
                        }
                    });
            });
        }
    }
}
