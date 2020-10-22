using belezanaweb.Application.Services;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Domain.Interfaces.Services;
using belezanaweb.Infra.Data.Repositories;
using belezanaweb.Infra.Data.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace belezanaweb.CrossCutting.IoC
{
    public static class ServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Database            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            //Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        }
    }
}
