using BelezaNaWeb.Domain.Entities.Products;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductBySkuAsync(long sku);
    }
}
