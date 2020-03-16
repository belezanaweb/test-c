using BelezaNaWeb.Application.Mapper;
using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.Services;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infrastructure.Data.Context;
using BelezaNaWeb.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BelezaNaWeb.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IMapper, Mapper>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<BelezaNaWebContext>();
        }
    }
}
