using ProductApi.Models;

namespace ProductApi.Repositories
{
    public interface IProductRepository
    {
        Product? GetProduct(int sku);
        List<Product> GetProducts();
        void CreateProduct(Product product);
        void UpdateProduct(int sku, Product product);
        void DeleteProduct(int sku);
    }
}