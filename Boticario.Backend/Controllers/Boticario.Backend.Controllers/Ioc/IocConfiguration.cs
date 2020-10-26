using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.Database;
using Boticario.Backend.Data.Database.Implementation;
using Boticario.Backend.Data.DatabaseContext;
using Boticario.Backend.Data.DatabaseContext.Implementation;
using Boticario.Backend.Data.UnitOfWork;
using Boticario.Backend.Data.UnitOfWork.Implementation;
using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Implementation.Factories;
using Boticario.Backend.Modules.Inventory.Implementation.Repositories;
using Boticario.Backend.Modules.Inventory.Implementation.Services;
using Boticario.Backend.Modules.Inventory.Repositories;
using Boticario.Backend.Modules.Inventory.Services;
using Boticario.Backend.Modules.Products.Factories;
using Boticario.Backend.Modules.Products.Implementation.Factories;
using Boticario.Backend.Modules.Products.Implementation.Repositories;
using Boticario.Backend.Modules.Products.Implementation.Services;
using Boticario.Backend.Modules.Products.Repositories;
using Boticario.Backend.Modules.Products.Services;
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
            this.AddFactories();
            this.AddServices();
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
            this.services.AddSingleton<IDatabase, MemoryDatabase>();

            this.services.AddScoped<IProductRepository, ProductRepository>();
            this.services.AddScoped<IInventoryRepository, InventoryRepository>();
        }

        private void AddFactories()
        {
            this.services.AddSingleton<IProductFactory, DefaultProductFactory>();
            this.services.AddSingleton<IInventoryFactory, DefaultInventoryFactory>();
        }

        private void AddServices()
        {
            this.services.AddScoped<IInventoryServices, DefaultInventoryServices>();
            this.services.AddScoped<IProductServices, DefaultProductServices>();
        }
    }
}
