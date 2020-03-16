using BelezaNaWeb.Tests.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BelezaNaWeb.Tests
{
    public class TestBase
    {
        private ServiceCollection ServiceCollection { get; set; } = new ServiceCollection();
        private IServiceProvider serviceProvider;

        public IServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                    serviceProvider = CreateServiceProvider();
                return serviceProvider;
            }
        }

        private IServiceProvider CreateServiceProvider()
        {
            ServiceCollection
                .AddDependencyInjectionSetup();

            return ServiceCollection.BuildServiceProvider();
        }
    }
}
