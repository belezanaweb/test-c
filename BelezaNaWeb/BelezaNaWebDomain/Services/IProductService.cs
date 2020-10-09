using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebDomain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();

        Task<Product> GetProductAsync(long sku);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(long sku);
    }
}