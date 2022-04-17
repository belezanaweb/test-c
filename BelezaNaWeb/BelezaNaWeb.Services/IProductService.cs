using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Response;

namespace BelezaNaWeb.Services
{
    public interface IProductService
    {
        Task<BaseResponse<Product>> CreateProduct(Product? product);
        Task<BaseResponse<bool>> DeleteProductBySku(int sku);
        Task<BaseResponse<Product>> GetAllProducts();
        Task<BaseResponse<Product>> GetBySku(int sku);
        Task<BaseResponse<bool>> UpdateBySku(int sku, Product? product);
    }
}
