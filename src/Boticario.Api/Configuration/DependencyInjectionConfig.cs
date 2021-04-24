using Boticario.Application;
using Boticario.Domain.Handlers;
using Boticario.Domain.Interfaces;
using Boticario.Infra.CrossCutting.Logging;
using Boticario.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Boticario.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        #region Public Methods

        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region Applications

            services.AddScoped<IProductApplication, ProductApplication>();

            #endregion

            #region Repositories

            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            #region Others

            services.AddScoped<ILogger, NLogLogger>();
            services.AddScoped<INotificator, NotificatorHandler>();

            #endregion

            return services;
        }

        #endregion
    }
}