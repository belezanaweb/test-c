using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BelezaNaWeb.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BELEZA NA WEB - DESENVOLVEDOR C# - Backend Test (Felipe Henrique Freire)",
                    Description = " Para essa avaliação foi utilizado .net Core 3.1. Esta é uma avaliação básica de código. O objetivo é conhecer um pouco do seu conhecimento/ prática de RESTful, C#.",
                    Contact = new OpenApiContact { Name = "Felipe Henrique Freire", Email = "felipehfreire@gmail.com", Url = new System.Uri("https://www.linkedin.com/in/felipe-freire-ab458a8b/") }
                });
            });
        }
    }
}
