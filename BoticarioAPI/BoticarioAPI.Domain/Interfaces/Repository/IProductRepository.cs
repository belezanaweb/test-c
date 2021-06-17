using BoticarioAPI.Domain.Entities;

namespace BoticarioAPI.Domain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetBySku(int sku);
    }
}
