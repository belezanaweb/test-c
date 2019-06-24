using BelezanaWeb.Infraestructure.Data.MongoDB.Repository;
using BelezanaWeb.Infrastructure.Data.Context;
using BelezanaWeb.Infrastructure.Data.SqlSever.Repositories.PoC;
using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Interface.Service;
using BelezanaWeb.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;

namespace BelezanaWeb.IoC
{
    public static class InjectorContainer
    {
        public static Container Container;

        public static void RegisterServices(IServiceCollection services)
        {
            try
            {
                // ASP.NET HttpContext dependency
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                // Service
                services.AddSingleton<IProductService, ProductService>();
                services.AddSingleton<IWarehouseService, WarehouseService>();
                services.AddSingleton<ILogService, LogService>();

                // Repository
                //services.AddDbContext<BelezanaWebContext>(opt => opt.UseInMemoryDatabase());

                services.AddSingleton<IProductRepository, ProductRepository>();
                services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
                services.AddSingleton<ILogRepository, LogRepository>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
