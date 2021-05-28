using Inventory.Core.Data;
using Inventory.Infrastructure.Database.Context;
using Inventory.Infrastructure.Database.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Infrastructure.Database.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddEfStorage(this IServiceCollection services)
        {
            services.AddTransient<DbContext>(service => service.GetRequiredService<ApplicationContext>());
            services.AddTransient(services =>
            {
                var optbuilder = new DbContextOptionsBuilder();                
                return optbuilder;
            });
            return services.AddScoped<IStorageRepository, Data.EFStorageRepository>();
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            
            return services.AddTransient<ProductQuery>();
        }
    }

}
