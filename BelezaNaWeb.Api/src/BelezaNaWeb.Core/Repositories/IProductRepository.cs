using BelezaNaWeb.Core.Model;

namespace BelezaNaWeb.Core.Repositories
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product Update(Product product);
        Product GetProductBySku(int sku);
        bool Delete(int sku);
    }
}
