using BoticarioAPI.Application.Application;
using BoticarioAPI.Domain.Interfaces.Application;
using BoticarioAPI.Domain.Interfaces.Repository;
using BoticarioAPI.Infra.Context;
using BoticarioAPI.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BoticarioAPI.DependencyInjection
{
    public class DependencyInjectionBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProductApp, ProductApp>();
            services.AddTransient<IWarehouseApp, WarehouseApp>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
        }
    }
}
