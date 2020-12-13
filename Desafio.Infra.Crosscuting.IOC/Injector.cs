using Desafio.Infra.Data.Interfaces;
using Desafio.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Infra.Data.Repository;
using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Domain.Interfaces;
using Desafio.Domain.ComandHandler;

namespace Desafio.Infra.Crosscuting.IOC
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IMainContext, MainContext>();
            services.AddScoped<IProductComandsHandler, ProductComandsHandler>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
