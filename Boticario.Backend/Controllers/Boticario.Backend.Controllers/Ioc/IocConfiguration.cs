using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.Connection.Implementation;
using Boticario.Backend.Data.UnitOfWork;
using Boticario.Backend.Data.UnitOfWork.Implementation;
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
        }

        private void AddConnectionObjects()
        {
            this.services.AddSingleton<IConnectionFactory, ConnectionFactoryImpl>();
            this.services.AddSingleton<IConnectionPool, ConnectionPoolImpl>();
            
            this.services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();
        }
    }
}
