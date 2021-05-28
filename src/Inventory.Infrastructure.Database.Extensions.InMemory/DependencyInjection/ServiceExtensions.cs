using Inventory.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Infrastructure.Database.Extensions.InMemory.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInMemoryRepository(this IServiceCollection services, string databaseName)
        {
            services.AddScoped(service =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseInMemoryDatabase(databaseName);
                return new ApplicationContext(optionsBuilder.Options);
            });
            return services;
        }
    }
}
