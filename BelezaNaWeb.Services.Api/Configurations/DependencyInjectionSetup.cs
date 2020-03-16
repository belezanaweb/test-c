using BelezaNaWeb.Infrastructure.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BelezaNaWeb.Services.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
