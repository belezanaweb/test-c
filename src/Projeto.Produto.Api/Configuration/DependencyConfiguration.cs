using Microsoft.Extensions.DependencyInjection;
using Projeto.Data.Produtos;
using Projeto.Data.Warehouses;
using Projeto.Domain.Interfaces;
using Projeto.Domain.Repositories;
using Projeto.Domain.Services;

namespace Projeto.Produtos.Api.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            AddRepository(services);
            AddDomain(services);

            return services;
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        }

        private static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ITelemetryService, TelemetryService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
