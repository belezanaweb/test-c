using BackEndTest.Application.DTOs;

namespace BackEndTest.Application.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductDTO product);
        Task<ProductDTO> GetProductBySku(int sku);
        Task<bool> RemoveProductBySku(int sku);
        Task<bool> UpdateProductBySku(ProductDTO product);
    }
}
