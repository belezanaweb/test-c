using BelezaNaWeb.Infrastructure.CrossCutting.IoC;
using BelezaNaWeb.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace BelezaNaWeb.Tests.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);

            services.Replace(new ServiceDescriptor(typeof(BelezaNaWebContext), (sp) =>
            {
                return new UnitTestDbContext();
            }
            ,ServiceLifetime.Scoped));
        }
    }
}
