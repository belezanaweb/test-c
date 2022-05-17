
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.domain.Entities;
using webapi.domain.Gateways;
using webapi.infrastructure.DataProviders.Repositories;
using Xunit;

namespace webapi.unittests.infrastructure
{
    public class ProductRepositoryTest
    {

        public ProductRepositoryTest()
        {

        }

        [Fact]
        public void DeleteItemExistenteRepository()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepository(memoryCache);

            int sku = 123;

            var product = new Product()
            {
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>() {
                        new Warehouse() {
                            locality = "123",
                            quantity = 2,
                            type = "TEST_TYPE" }
                    }
                },
                name = "TESTE NOME PRODUTO",
                sku = 123
            };

            _productRepository.Insert(product);
            var result = _productRepository.Get(sku).Result;
            Assert.NotNull(result);
            _productRepository.Delete(sku);
            result = _productRepository.Get(sku).Result;
            Assert.Null(result);
        }

        [Fact]
        public void GetItemExistenteRepository()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepository(memoryCache);

            int sku = 123;

            var product = new Product()
            {
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>() {
                        new Warehouse() {
                            locality = "123",
                            quantity = 2,
                            type = "TEST_TYPE" }
                    }
                },
                name = "TESTE NOME PRODUTO",
                sku = 123
            };

            _productRepository.Insert(product);
            var result = _productRepository.Get(sku).Result;
            Assert.NotNull(result);
            Assert.Equal(product.sku, result.sku);
            Assert.Equal(product.name, result.name);

        }

        [Fact]
        public void GetItemInexistenteRepository()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepository(memoryCache);

            int sku = 123;

            var result = _productRepository.Get(sku).Result;
            Assert.Null(result);            
        }

        [Fact]
        public void UpdateItemRepository()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepository(memoryCache);

            int sku = 123;

            var product = new Product()
            {
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>() {
                        new Warehouse() {
                            locality = "123",
                            quantity = 2,
                            type = "TEST_TYPE" }
                    }
                },
                name = "TESTE NOME PRODUTO",
                sku = 123
            };

            _productRepository.Insert(product);
            var result = _productRepository.Get(sku).Result;
            Assert.NotNull(result);
            Assert.Equal(product.sku, result.sku);
            Assert.Equal(product.name, result.name);

            var novoNome = "TESTE 2";

            product.name = novoNome;
            var resultUpdate = _productRepository.Update(product);
            Assert.NotNull(result);
            Assert.Equal(product.sku, result.sku);
            Assert.Equal(novoNome, result.name);
        }
       
        [Fact]
        public void InsertItemRepository() {

            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var _productRepository = new ProductRepository(memoryCache);

            int sku = 123;

            var product = new Product()
            {
                inventory = new Inventory()
                {
                    warehouses = new List<Warehouse>() {
                        new Warehouse() {
                            locality = "123",
                            quantity = 2,
                            type = "TEST_TYPE" }
                    }
                },
                name = "TESTE NOME PRODUTO",
                sku = 123
            };

            _productRepository.Insert(product);
            var result = _productRepository.Get(sku).Result;
            Assert.NotNull(result);
            Assert.Equal(product.sku, result.sku);
        }


    }
}
