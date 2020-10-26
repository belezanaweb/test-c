using Boticario.Backend.Modules.Inventory.Dto;
using Boticario.Backend.Modules.Inventory.Implementation.Services;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Tests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Tests
{
    public class DefaultInventoryServicesTests
    {
        private InventoryRepositoryMock inventoryRepository;
        private InventoryFactoryMock inventoryFactory;
        private DefaultInventoryServices inventoryServices;

        [SetUp]
        public void Setup()
        {
            this.inventoryRepository = new InventoryRepositoryMock();
            this.inventoryFactory = new InventoryFactoryMock();
            this.inventoryServices = new DefaultInventoryServices(this.inventoryRepository, this.inventoryFactory);
        }

        [Test]
        public async Task When_ThereIsNotInventoryForSKU_Should_ReturnEmptyList()
        {
            IInventoryDetails inventoryDetails = await this.inventoryServices.GetAll(0);

            Assert.IsEmpty(inventoryDetails.Warehouses);
        }

        [Test]
        public async Task When_ThereAreInventoriesForSKU_Should_ReturnOrderedListByLocalityAndType()
        {
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Zzz", Quantity = 10, Type = "Mmm" });
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Aaa", Quantity = 20, Type = "Jjj" });
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Aaa", Quantity = 30, Type = "Bbb" });

            IInventoryDetails inventoryDetails = await this.inventoryServices.GetAll(0);

            Assert.AreEqual(3, inventoryDetails.Warehouses.Count);
            
            Assert.AreEqual("Aaa", inventoryDetails.Warehouses[0].Locality);
            Assert.AreEqual("Bbb", inventoryDetails.Warehouses[0].Type);

            Assert.AreEqual("Aaa", inventoryDetails.Warehouses[1].Locality);
            Assert.AreEqual("Jjj", inventoryDetails.Warehouses[1].Type);

            Assert.AreEqual("Zzz", inventoryDetails.Warehouses[2].Locality);
            Assert.AreEqual("Mmm", inventoryDetails.Warehouses[2].Type);
        }

        [Test]
        public async Task When_ThereIsNoInventoryForSave_Should_NotCallSaveMethod()
        {
            await this.inventoryServices.SaveAll(0, new InventoryOperationDto() { Warehouses = new List<InventoryWarehouseOperationDto>(0) });

            Assert.IsFalse(this.inventoryRepository.SaveAllWasCalled);
        }

        [Test]
        public async Task When_WharehouseListIsNull_Should_NotCallSaveMethod()
        {
            await this.inventoryServices.SaveAll(0, new InventoryOperationDto() { Warehouses = null });

            Assert.IsFalse(this.inventoryRepository.SaveAllWasCalled);
        }

        [Test]
        public async Task When_SaveIsCalledFor5Itens_Should_CallFactory5Times()
        {
            await this.inventoryServices.SaveAll(0, new InventoryOperationDto()
            {
                Warehouses = new List<InventoryWarehouseOperationDto>()
                {
                    new InventoryWarehouseOperationDto() { Locality = "Aaa", Quantity = 10, Type = "Zzz" },
                    new InventoryWarehouseOperationDto() { Locality = "Bbb", Quantity = 20, Type = "Zzz" },
                    new InventoryWarehouseOperationDto() { Locality = "Ccc", Quantity = 30, Type = "Zzz" },
                    new InventoryWarehouseOperationDto() { Locality = "Dee", Quantity = 40, Type = "Zzz" },
                    new InventoryWarehouseOperationDto() { Locality = "Eee", Quantity = 50, Type = "Zzz" },
                }
            });

            Assert.AreEqual(5, this.inventoryFactory.CreateEntityEvents);
        }

        [Test]
        public async Task When_SaveIsCalledFor1Item_Should_Save1ItemWithTheSameValuesInformed()
        {
            await this.inventoryServices.SaveAll(0, new InventoryOperationDto()
            {
                Warehouses = new List<InventoryWarehouseOperationDto>()
                {
                    new InventoryWarehouseOperationDto() { Locality = "Aaa", Quantity = 10, Type = "Zzz" }
                }
            });

            Assert.IsTrue(this.inventoryRepository.SaveAllWasCalled);
            Assert.AreEqual("Aaa", this.inventoryRepository.Database[0].Locality);
            Assert.AreEqual(10, this.inventoryRepository.Database[0].Quantity);
            Assert.AreEqual("Zzz", this.inventoryRepository.Database[0].Type);
        }

        [Test]
        public async Task When_DeleteInventories_Should_TheDatabaseBeClean()
        {
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Zzz", Quantity = 10, Type = "Mmm" });
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Aaa", Quantity = 20, Type = "Jjj" });
            this.inventoryRepository.Database.Add(new InventoryEntityMock() { Locality = "Aaa", Quantity = 30, Type = "Bbb" });

            await this.inventoryServices.DeleteAll(0);

            Assert.IsTrue(this.inventoryRepository.DeleteAllWasCalled);
        }
    }
}
