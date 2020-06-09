using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_beauty.Models;
using web_beauty.Repositories;

namespace web_beauty.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
        }

        public async Task<Product> GetBySku(long sku)
        {
            return await _productRepository.GetBySku(sku);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Delete(Product product)
        {
            await _productRepository.Delete(product);
        }
    }
}
