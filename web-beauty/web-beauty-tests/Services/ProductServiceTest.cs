using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_beauty.Data;
using web_beauty.Models;
using web_beauty.Repositories;
using web_beauty.Services;
using Xunit;

namespace web_beauty_tests.Services
{
    public class ProductServiceTest
    {        
        private Product _productDummy;
        public void InitTest()
        {
            _productDummy = new Product()
            {
                Id = "5ee15aa59fb71e3d5c1f50a6",
                Sku = 123456,
                Name = "Product Dummy",
                Inventory = new Inventory()
                {
                    Quantity = null,
                    Warehouses = new List<Warehouse>()
                        {   new Warehouse() { Locality = "Local A" , Quantity = 10, Type = "ECOMMERCE"},
                            new Warehouse() { Locality = "Local A" , Quantity = 10, Type = "ECOMMERCE"}
                    }
                },
                IsMarketable = null
            };
        }

        [Fact]
        public async Task CreateProductSkuAlreadyExists()
        {
            InitTest();

            var context = new Mock<IContext>();
            var repo = new Mock<IProductRepository>();

            repo.Setup(u => u.GetBySku(It.IsAny<long>()))
                .Returns(Task.FromResult(_productDummy));


            var service = new ProductService(repo.Object);

            await Assert.ThrowsAsync<Exception>(() => service.CreateProduct(_productDummy));
        }

        [Fact]
        public async Task CreateProductSetNullIsMarketableAndQuantity()
        {
            InitTest();

            var context = new Mock<IContext>();
            var repo = new Mock<IProductRepository>();

            repo.Setup(u => u.GetBySku(It.IsAny<long>()))
                .Returns(Task.FromResult<Product>(null));

            repo.Setup(u => u.CreateProduct(It.IsAny<Product>()))
                .Returns(Task.FromResult(_productDummy));

            _productDummy.IsMarketable = true;
            _productDummy.Inventory.Quantity = 100;

            var service = new ProductService(repo.Object);

            await service.CreateProduct(_productDummy);

            Assert.Null(_productDummy.IsMarketable);
            Assert.Null(_productDummy.Inventory.Quantity);
        }

        [Fact]
        public async Task UpdateNonExistentProductException()
        {
            InitTest();

            var context = new Mock<IContext>();
            var repo = new Mock<IProductRepository>();

            repo.Setup(u => u.GetBySku(It.IsAny<long>()))
                .Returns(Task.FromResult<Product>(null));

            var productRepository = new ProductRepository(context.Object);

            var service = new ProductService(repo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Update(_productDummy));
        }
    }
}
