using System.Net;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Response;
using BelezaNaWeb.Repository;

namespace BelezaNaWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<Product>> CreateProduct(Product? product)
        {
            var response = new BaseResponse<Product>();

            if (product is not null && _productRepository.GetBySku(product.Sku) is null)
            {
                response.Data.Add(_productRepository.Create(product));
                response.Message = "Product has been created";
                response.HttpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                throw new Exception($"Product already exist with this sku: {product.Sku}");
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteProductBySku(int sku)
        {
            var response = new BaseResponse<bool>();

            if (_productRepository.GetBySku(sku) is not null)
            {
                _productRepository.DeleteBySku(sku);
                response.HttpStatusCode = HttpStatusCode.OK;
                response.Message = "Product has been deleted";
                response.Data.Add(true);
            }
            else
            {
                response.HttpStatusCode = HttpStatusCode.NotFound;
                response.Data.Add(false);
                response.Message = "Product not found";
            }

            return response;
        }

        public async Task<BaseResponse<Product>> GetAllProducts()
        {
            var response = new BaseResponse<Product>();
            var helper = _productRepository.GetProducts();
            if (helper is not null)
            {
                response.Data.AddRange(helper);
            }
            response.HttpStatusCode = HttpStatusCode.OK;
            response.Message = "Products has been retrieved";

            return response;
        }

        public async Task<BaseResponse<Product>> GetBySku(int sku)
        {
            var response = new BaseResponse<Product>();
            var helper = _productRepository.GetBySku(sku);
            if (helper is not null)
            {
                response.Data.Add(helper);
                response.HttpStatusCode = HttpStatusCode.OK;
                response.Message = "Product has been retrieved";
            }
            else
            {
                response.HttpStatusCode = HttpStatusCode.NotFound;
                response.Message = "Product not found";
            }
            

            return response;
        }
        public async Task<BaseResponse<bool>> UpdateBySku(int sku, Product? product)
        {
            var response = new BaseResponse<bool>();
            var helper = _productRepository.GetBySku(sku);
            if (helper is not null && product is not null)
            {
                _productRepository.UpdateBySku(sku, product);
                response.Data.Add(true);
                response.HttpStatusCode = HttpStatusCode.OK;
                response.Message = "Product updated";
            }
            else
            {
                response.HttpStatusCode = HttpStatusCode.NotFound;
                response.Message = "Product Not Fount";
            }

            return response;
        }
    }
}