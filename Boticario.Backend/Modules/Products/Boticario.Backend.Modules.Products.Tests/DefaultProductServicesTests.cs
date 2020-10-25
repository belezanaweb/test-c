using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Implementation.Factories;
using Boticario.Backend.Modules.Products.Implementation.Services;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Tests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Tests
{
    public class DefaultProductServicesTests
    {
        private ProductRepositoryMock productRepository;
        private InventoryServiceMock inventoryService;
        private DefaultProductFactory productFactory;
        private DefaultProductServices productservices;
        
        [SetUp]
        public void Setup()
        {
            this.productRepository = new ProductRepositoryMock();
            this.inventoryService = new InventoryServiceMock();
            this.productFactory = new DefaultProductFactory();
            this.productservices = new DefaultProductServices(this.productRepository, this.inventoryService, this.productFactory);
        }

        [Test]
        public async Task When_ThereIsNotProductForSKU_Should_ReturnNull()
        {
            IProductDetails result = await this.productservices.Get(0);

            Assert.IsNull(result);
        }

        [Test]
        public async Task When_ThereIsAProductForSKU_Should_ReturnObject()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.Inventories = new List<IInventoryEntity>()
            {
                new InventoryEntityMock() { Locality = "A", Quantity = 10, Type = "AA"},
                new InventoryEntityMock() { Locality = "B", Quantity = 20, Type = "BB"}
            };

            IProductDetails result = await this.productservices.Get(0);

            Assert.IsNotNull(result);
        }
    }
}
