using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.Domain.Interfaces.Products;
using BelezaNaWeb.Infrastructure.EntityFramework;
using BelezaNaWeb.Infrastructure.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BelezaNaWeb.Infrastructure
{
    public static class ProductStartup
    {
        public static void AddProductModule(this IServiceCollection services, Action<ProductConfiguration> setupAction)
        {
            services.Configure(setupAction);
            services.AddDbContext<ProductDbContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<INotificationContext, NotificationContext>();
        }
    }
}
