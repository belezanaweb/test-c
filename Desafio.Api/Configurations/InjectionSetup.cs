using Desafio.Infra.Crosscuting.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Api.Configurations
{
    public static class InjectionSetup
    {
        public static void AddInjectionSetup(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }
    }
}
