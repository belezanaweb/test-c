using Boticario.Domain.Entities;

namespace Boticario.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product GetProductBySku(int sku);
        Product Add(Product product);
        Product Update(Product product);
        bool Delete(int sku);
    }
}