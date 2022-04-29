using BackEndTest.Application.Interfaces;
using BackEndTest.Application.Mappings;
using BackEndTest.Application.Services;
using BackEndTest.Domain.Interfaces;
using BackEndTest.Infra.Data.Context;
using BackEndTest.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndTest.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            return services;
        }
    }
}
