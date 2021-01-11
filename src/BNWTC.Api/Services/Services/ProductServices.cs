using BNWTC.Api.Data.Repositories.Interface;
using BNWTC.Api.Models.Entities;
using BNWTC.Api.Services.IServices;

using System.Threading.Tasks;

namespace BNWTC.Api.Services.Services
{
    public class ProductServices : IProductSerices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> FindBySku(int sku)
        {
            return await _productRepository.FindBySku(sku);
        }

        public async Task<Product> Add(Product product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<Product> Update(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<bool> Remove(Product product)
        {
            return await _productRepository.Remove(product);
        }
    }
}
