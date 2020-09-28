using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Inventory.api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                t =>
                { t.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Inventory Api", Version = "v1" }); });

            return services;
        }
    }
}
