using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebDomain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        Task AddAync(Product product);

        Task<Product> FindByIdAsync(long sku);

        void Update(Product product);

        void Remove(Product product);
    }
}