using Boticario.Backend.Data.Connection;
using Boticario.Backend.Data.Connection.Implementation;
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

            //this.AddConfigurations();
            //this.AddSessions();

            //this.AddRepositories();
            //this.AddServices();
            //this.AddLegacyServices();
        }

        private void AddConnectionObjects()
        {
            this.services.AddSingleton<IConnectionFactory, ConnectionFactoryImpl>();
            this.services.AddSingleton<IConnectionPool, ConnectionPoolImpl>();
        }
    }
}
