using AutoMapper;
using BrunoTragl.BelezaNaWeb.Application.Services;
using BrunoTragl.BelezaNaWeb.Application.Services.Interfaces;
using BrunoTragl.BelezaNaWeb.Domain.Repository;
using BrunoTragl.BelezaNaWeb.Domain.Repository.Interfaces;
using BrunoTragl.BelezaNaWeb.Infra.Data;
using BrunoTragl.BelezaNaWeb.Infra.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependences(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<IInventoryService, InventoryService>();
            service.AddSingleton<IContext, Context>();
            service.AddSingleton(configuration);
            service.AddAutoMapper(typeof(Startup));
        }
    }
}
