using GrupoBoticario.Domain.Interfaces;
using GrupoBoticario.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoBoticario.Domain.Extensions
{
    public static class DomainExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductService), typeof(ProductService));
        }
    }
}
