using belezanaweb.Domain.Entities;
using System.Threading.Tasks;

namespace belezanaweb.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> FindBySkuAsync(int sku);
    }
}
