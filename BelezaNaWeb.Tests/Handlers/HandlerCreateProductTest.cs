using BelezaNaWeb.Domain.Commands.CreateProductCommand.Input;
using BelezaNaWeb.Domain.Handlers;
using BelezaNaWeb.Infra.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace BelezaNaWeb.Tests.Handlers
{
    [TestFixture]
    public class HandlerCreateProductTest {

        WarehouseCommand warehouse1;
        WarehouseCommand warehouse2;
        WarehouseCommand warehouseZero;

        CreateProductCommand validCommand;
        CreateProductCommand isMarketableFalseCommand;
        CreateProductCommand invalidCommand;

        InventoryCommand inventory;

        ProductRepository repository;
        ProductHandler handler;

        [SetUp]
        public void SetUp() {
            warehouse1 = new WarehouseCommand {
                locality = "SP",
                quantity = 12,
                type = "PHYSICAL_STORE"
            };

            warehouse2 = new WarehouseCommand {
                locality = "SP",
                quantity = 12,
                type = "ECOMMERCE"
            };

            warehouseZero = new WarehouseCommand {
                locality = "SP",
                quantity = 0,
                type = "PHYSICAL_STORE"
            };
            var tempList = new List<WarehouseCommand>();
            tempList.Add(warehouse1);
            tempList.Add(warehouse2);

            inventory = new InventoryCommand();
            inventory.warehouses = tempList.ToArray();


            validCommand = new CreateProductCommand {
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                sku = 43264,
                inventory = inventory
            };

            var zeroTempList = new List<WarehouseCommand>();
            var isMarketableFalseInventory = new InventoryCommand {
                warehouses = zeroTempList.ToArray()
            };

            isMarketableFalseCommand = new CreateProductCommand {
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                sku = 43264,
                //inventory = isMarketableFalseInventory
            };

            invalidCommand = new CreateProductCommand
            {
                name = "",
                sku = 0
            };

            repository = new ProductRepository();
            handler = new ProductHandler(repository);
        }

        [Test]
        public void shouldBePossibleToAddNewProducts() {
            var response = handler.handle(validCommand);
            Assert.IsTrue(response.success);
        }

        //Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada
        [Test]
        public void skuShouldBeUnique() {
            var firtResponse = handler.handle(validCommand);
            var secondResponse = handler.handle(validCommand);

            Assert.IsTrue(firtResponse.success);
            Assert.IsFalse(secondResponse.success);
        }

        //A propriedade inventory.quantity é a soma da quantity dos warehouses
        [Test]
        public void shouldInventoryQuantityCanBeTheSumOfQuantityOfWarehouses() {
            var response = handler.handle(validCommand);
            var savedData = repository.getProduct(validCommand.sku);
            var inventoryQuantity = 0;

            foreach (var warehouse in savedData.inventory.warehouses) {
                inventoryQuantity += warehouse.quantity;
            }

            Assert.IsTrue(response.success);
            Assert.IsTrue(savedData.inventory.quantity == inventoryQuantity);
        }

        [Test]
        public void shouldBeIsMarketableFalse() {
            var response = handler.handle(isMarketableFalseCommand);
            var savedData = repository.getProduct(isMarketableFalseCommand.sku);

            Assert.IsTrue(response.success);
            Assert.IsFalse(savedData.isMarketable);
        }
        [Test]
        public void shouldBeReturnInvalidForCommand() {
            var response = handler.handle(invalidCommand);
            Assert.IsFalse(response.success);
        }
    }
}
