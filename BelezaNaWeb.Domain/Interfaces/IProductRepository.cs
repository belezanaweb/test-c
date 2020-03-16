using BelezaNaWeb.Domain.Models;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Product GetBySku(int sku);
    }
}
