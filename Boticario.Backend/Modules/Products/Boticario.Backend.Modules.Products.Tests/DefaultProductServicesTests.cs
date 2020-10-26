using Boticario.Backend.Modules.Inventory.Dto;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Dto;
using Boticario.Backend.Modules.Products.Implementation.Factories;
using Boticario.Backend.Modules.Products.Implementation.Services;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Products.Tests
{
    public class DefaultProductServicesTests
    {
        private ProductRepositoryMock productRepository;
        private InventoryServiceMock inventoryService;
        private UnitOfWorkMock unitOfWork;
        private DefaultProductServices productServices;

        [SetUp]
        public void Setup()
        {
            this.productRepository = new ProductRepositoryMock();
            this.inventoryService = new InventoryServiceMock();
            this.unitOfWork = new UnitOfWorkMock();
            this.productServices = new DefaultProductServices(this.productRepository, this.inventoryService, new DefaultProductFactory(), this.unitOfWork);
        }

        [Test]
        public async Task When_ThereIsNotProductForSKU_Should_ReturnNull()
        {
            IProductDetails result = await this.productServices.Get(0);

            Assert.IsNull(result);
        }

        [Test]
        public async Task When_ThereIsAProductForSKU_Should_ReturnObject()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" });
            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "B", Quantity = 20, Type = "BB" });

            IProductDetails result = await this.productServices.Get(0);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task When_SaveNewProduct_Should_PersistObject()
        {
            await this.productServices.Create(new ProductOperationDto()
            {
                Sku = 1,
                Name = "Abc",
                Inventory = new InventoryOperationDto()
                {
                    Warehouses = new List<InventoryWarehouseOperationDto>()
                    {
                        new InventoryWarehouseOperationDto()
                        {
                            Locality = "A",
                            Quantity = 10,
                            Type = "AA"
                        }
                    }
                }
            });

            Assert.AreEqual(1, this.productRepository.Database.Sku);
            Assert.AreEqual("Abc", this.productRepository.Database.Name);
            Assert.IsTrue(this.inventoryService.SaveAllWasCalled);
        }

        [Test]
        public void When_SaveProductWithNullObject_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await this.productServices.Create(null);
            });

            Assert.AreEqual("Product is Null!", exception.Message);
        }

        [Test]
        public async Task When_SaveNewProduct_Should_UseUnitOfWork()
        {
            await this.productServices.Create(new ProductOperationDto()
            {
                Sku = 1,
                Name = "Abc",
                Inventory = new InventoryOperationDto()
                {
                    Warehouses = new List<InventoryWarehouseOperationDto>()
                    {
                        new InventoryWarehouseOperationDto()
                        {
                            Locality = "A",
                            Quantity = 10,
                            Type = "AA"
                        }
                    }
                }
            });

            Assert.IsTrue(this.unitOfWork.UsedUnifOfWork);
        }

        [Test]
        public async Task When_UpdateAnExistingProduct_Should_PersistObject()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" });
            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "B", Quantity = 20, Type = "BB" });

            await this.productServices.Update(new ProductOperationDto()
            {
                Sku = 1,
                Name = "Def",
                Inventory = new InventoryOperationDto()
                {
                    Warehouses = new List<InventoryWarehouseOperationDto>()
                    {
                        new InventoryWarehouseOperationDto()
                        {
                            Locality = "A",
                            Quantity = 100,
                            Type = "AA"
                        },
                        new InventoryWarehouseOperationDto()
                        {
                            Locality = "B",
                            Quantity = 200,
                            Type = "BB"
                        }
                    }
                }
            });

            Assert.AreEqual(1, this.productRepository.Database.Sku);
            Assert.AreEqual("Def", this.productRepository.Database.Name);
            Assert.IsTrue(this.inventoryService.SaveAllWasCalled);
        }

        [Test]
        public void When_UpdateAnExistingProductWithNullObject_Should_ThrowException()
        {
            Exception exception = Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await this.productServices.Update(null);
            });

            Assert.AreEqual("Product is Null!", exception.Message);
        }

        [Test]
        public async Task When_UpdateAnExistingProduct_Should_UseUnitOfWork()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" });
            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "B", Quantity = 20, Type = "BB" });

            await this.productServices.Update(new ProductOperationDto()
            {
                Sku = 1,
                Name = "Def",
                Inventory = new InventoryOperationDto()
            });

            Assert.IsTrue(this.unitOfWork.UsedUnifOfWork);
        }

        [Test]
        public async Task When_DeleteAnExistingProduct_Should_RemoveObject()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" });
            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "B", Quantity = 20, Type = "BB" });

            await this.productServices.Delete(1);

            Assert.IsNull(this.productRepository.Database);
            Assert.IsTrue(this.inventoryService.SaveAllWasCalled);
        }

        [Test]
        public async Task When_DeleteAnExistingProduct_Should_UseUnitOfWork()
        {
            this.productRepository.Database = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            this.inventoryService.InventoryDetails.Warehouses.Add(new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" });
            
            await this.productServices.Delete(1);

            Assert.IsTrue(this.unitOfWork.UsedUnifOfWork);
        }
    }
}
