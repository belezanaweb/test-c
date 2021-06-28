using GrupoBoticario.DataAccess.Repositories;
using GrupoBoticario.DataAccess.Repositories.Generic;
using GrupoBoticario.Domain.IRepositories;
using GrupoBoticario.Domain.IRepositories.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoBoticario.DataAccess.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IInventoryRepository), typeof(InventoryRepository));
            services.AddScoped(typeof(IWareHouseRepository), typeof(WareHouseRepository));
        }
    }
}
