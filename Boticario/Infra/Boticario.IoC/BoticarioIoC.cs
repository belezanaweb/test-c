using Microsoft.Extensions.DependencyInjection;
using Boticario.Domain.Interfaces.Repositories;
using Boticario.Domain.Interfaces.Services;
using Boticario.Domain.Services;
using Boticario.Reporitory.Repositories;

namespace Boticario.IoC
{
    public static class BoticarioIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
