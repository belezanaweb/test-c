using GrupoBoticario.Application.Interfaces;
using GrupoBoticario.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoBoticario.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IProductApplicationService), typeof(ProductApplicationService));
        }
    }
}
