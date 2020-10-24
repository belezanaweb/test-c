using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.DatabaseContext;
using Boticario.Backend.Data.DatabaseContext.Implementation;
using Boticario.Backend.Data.UnitOfWork;
using Boticario.Backend.Data.UnitOfWork.Implementation;
using Boticario.Backend.Modules.Inventory.Repositories;
using Boticario.Backend.Modules.Products.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Boticario.Backend.Controllers.Ioc
{
    internal class IocConfiguration
    {
        private readonly IServiceCollection services;

        public IocConfiguration(IServiceCollection services)
        {
            this.services = services;
        }

        public void Config()
        {
            this.AddConnectionObjects();
            this.AddRepositories();
        }

        private void AddConnectionObjects()
        {
            this.services.AddSingleton<IConnectionFactory, DefaultConnectionFactory>();
            this.services.AddSingleton<IConnectionPool, DefaultConnectionPool>();
            
            this.services.AddScoped<IUnitOfWork, DefaultUnitOfWork>();
            this.services.AddScoped<IDatabaseContext, DefaultDatabaseContext>();
        }

        private void AddRepositories()
        {
            this.services.AddSingleton<IProductRepository, ProductRepository>();
            this.services.AddSingleton<IInventoryRepository, InventoryRepository>();
        }
    }
}
