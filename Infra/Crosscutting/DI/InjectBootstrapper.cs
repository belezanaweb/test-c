using Application.Services;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Infra.Data;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Crosscutting.DI
{
    public class InjectBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<Context>();
        }
    }
}
