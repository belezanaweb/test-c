using BelezaNaWeb.Core.Model;

namespace BelezaNaWeb.Core.Services
{
    public interface IProductServices
    {
        Product Add(Product product);
        Product Update(Product product);
        Product GetProductBySku(int sku);
        bool Delete(int sku);
    }
}
