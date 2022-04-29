using BackEndTest.Domain.Entities;

namespace BackEndTest.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<Product> GetProductBySkuAsync(int sku);
        Task<bool> RemoveProductBySkuAsync(int sku);
        Task<bool> UpdateProductBySkuAsync(Product product);
    }
}
