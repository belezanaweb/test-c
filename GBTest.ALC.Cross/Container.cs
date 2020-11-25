using Microsoft.Extensions.DependencyInjection;

namespace GBTest.ALC.Cross
{
    public class Container
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<Domain.Interfaces.IProductRepository, Infra.Data.Local.Repositories.ProductRepository>();
            services.AddSingleton<Domain.Interfaces.IProductService, Domain.Services.ProductService>();
        }
    }
}
