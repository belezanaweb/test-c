using BelezaNaWeb.Domain.Commands.UpdateProductCommand.Input;
using BelezaNaWeb.Domain.Handlers;
using BelezaNaWeb.Infra.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Tests.Handlers
{
    [TestFixture]
    public class HandleUpdateCommandTest {
        WarehouseCommand warehouse1;
        WarehouseCommand warehouse2;
        UpdateProductCommand validCommand;
        InventoryCommand inventory;
        UpdateProductCommand invalidCommand;
        ProductRepository repository;
        ProductHandler handler;

        [SetUp]
        public void SetUp()
        {
            warehouse1 = new WarehouseCommand
            {
                locality = "SP",
                quantity = 12,
                type = "PHYSICAL_STORE"
            };

            warehouse2 = new WarehouseCommand
            {
                locality = "SP",
                quantity = 12,
                type = "ECOMMERCE"
            };

            var tempList = new List<WarehouseCommand>();
            tempList.Add(warehouse1);
            tempList.Add(warehouse2);

            inventory = new InventoryCommand();
            inventory.warehouses = tempList.ToArray();

            validCommand = new UpdateProductCommand {
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                sku = 43264,
                inventory = inventory
            };

            invalidCommand = new UpdateProductCommand {
                name = "",
                sku = 0
            };

            repository = new ProductRepository();
            handler = new ProductHandler(repository);
        }

        [Test]
        public void shouldBePossibleToUpdateProduct()
        {
            var response = handler.handle(validCommand);
            Assert.IsTrue(response.success);
        }

        [Test]
        public void shouldBeReturnInvalidForCommand()
        {
            var response = handler.handle(invalidCommand);
            Assert.IsFalse(response.success);
        }


    }
}
