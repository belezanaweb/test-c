using BelezaNaWeb.Domain.Entities;

namespace BelezaNaWeb.Repository
{
    public interface IProductRepository
    {
        Product? GetBySku(int sku);
        List<Product> GetProducts();
        Product Create(Product product);
        void UpdateBySku(int sku, Product product);
        void DeleteBySku(int sku);
    }
}
