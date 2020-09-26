using System;
using BelezaNaWeb.Api.Extensions;
using BelezaNaWeb.Framework.Helpers;
using BelezaNaWeb.Framework.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.Test.Infrastructure
{
    public sealed class ContainerFixture
    {
        #region Public Properties

        public IServiceProvider ServiceProvider { get; }

        #endregion

        #region Constructors

        public ContainerFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddApiDependencies()
                .AddFrameworkDependencies();

            ServiceProvider = serviceCollection.BuildServiceProvider();
            DbGeneratorHelper.Create(ServiceProvider);
        }

        #endregion
    }
}
