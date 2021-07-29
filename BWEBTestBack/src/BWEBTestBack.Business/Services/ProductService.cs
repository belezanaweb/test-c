using BWEBTestBack.Business.Interfaces;
using BWEBTestBack.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BWEBTestBack.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public ProductService(IProductRepository productRepository,
                              IInventoryRepository inventoryRepository,
                              IWarehouseRepository warehouseRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task Add(Product product)
        {
            var prod = await _productRepository.GetBySku(product.Sku);
            if (prod == null)
            {
                await _productRepository.Add(product);
            } else
            {
                throw new Exception("Já existe um produto com esta SKU");
            }                        
        }

        public async Task Update(Product product)
        {
            var prod = await _productRepository.GetBySku(product.Sku);
            
            if (prod != null)
            {
                prod.Name = product.Name;

                 await _productRepository.Update(prod);
            } else
            {
                await _productRepository.Add(product);
            }
            
        }

        public async Task Delete(int sku)
        {            
            var product = await _productRepository.GetBySku(sku);
            var inventory = await _inventoryRepository.GetByProductId(product.Id);
            var warehouse = await _warehouseRepository.GetByInventoryId(inventory.Id);

            if (warehouse != null)
            {
                await _warehouseRepository.DeleteInventoryId(inventory.Id);
            }
            if (inventory != null)
            {
                await _inventoryRepository.DeleteByProductId(product.Id);
            }
            await _productRepository.DeleteBySku(sku);           
        }

        public async Task<Product> Get(int sku)
        {
            var product = await _productRepository.GetBySku(sku);            

            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
    }
}
