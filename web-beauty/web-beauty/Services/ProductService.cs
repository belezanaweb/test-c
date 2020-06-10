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
            var skuExists = await SkuExists(product.Sku);

            if (skuExists)
                throw new Exception($"There is already a product with the same SKU in the database");

            product.IsMarketable = null;
            product.Inventory.Quantity = null;

            await _productRepository.CreateProduct(product);
        }

        private async Task<bool> SkuExists(long sku)
        {
            var product = await _productRepository.GetBySku(sku);

            return product != null;
        }

        public async Task<Product> GetBySku(long sku)
        {
            var product = await _productRepository.GetBySku(sku);

            product.CalculateQuantity();
            product.SetIsMarketable();

            return product;
        }

        public async Task Update(Product product)
        {
            var productFromDb = await _productRepository.GetBySku(product.Sku) ;

            if (productFromDb == null)
                throw new ArgumentNullException($"Product with sku {product.Sku} not found");

            product.Id = productFromDb.Id;

            await _productRepository.Update(product);
        }

        public async Task Delete(long sku)
        {

            await _productRepository.Delete(sku);
        }
    }
}
