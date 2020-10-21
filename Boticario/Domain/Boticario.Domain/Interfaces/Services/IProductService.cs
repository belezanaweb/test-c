using Boticario.Domain.Entities;

namespace Boticario.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Product GetProductBySku(int sku);
        Product Add(Product product);
        Product Update(Product product);
        bool Delete(int sku);
    }
}
