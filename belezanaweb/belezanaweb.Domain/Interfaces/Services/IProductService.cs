using belezanaweb.Domain.Entities;
using System.Threading.Tasks;

namespace belezanaweb.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<Product> FindBySkuAsync(int sku);
    }
}
