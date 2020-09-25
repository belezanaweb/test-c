using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Routing;
using BelezaNaWeb.Framework.Data.Contexts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BelezaNaWeb.Framework.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BelezaNaWeb.Framework.Extensions
{
    public static class IServiceCollectionExtensions
    {
        #region Extension Methods

        public static IServiceCollection AddFrameworkDependencies(this IServiceCollection services, bool enableSensitiveData = false)
        {            
            services
                .AddDbContext<ApiContext>(options =>
                {
                    options.EnableSensitiveDataLogging(enableSensitiveData);
                    options.UseInMemoryDatabase(databaseName: nameof(ApiContext));
                });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.TryAddScoped(x =>
            {
                var context = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(context);
            });

            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(c => c.AssignableTo(typeof(IGenericRepository<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                );

            return services;
        }

        #endregion
    }
}
