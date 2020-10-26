using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Implementation.BusinessLogic;
using Boticario.Backend.Modules.Products.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Backend.Modules.Products.Tests
{
    public class DefaultMarketableCalculatorTests
    {
        private DefaultMarketableCalculator calculator;

        [SetUp]
        public void Setup()
        {
            this.calculator = new DefaultMarketableCalculator();
        }

        [Test]
        public void When_ListIsEmpty_Should_ReturnFalse()
        {
            IInventoryDetails inventoryDetails = new InventoryDetailsMock()
            {
                Quantity = 0,
                Warehouses = new List<IInventoryWarehouse>()
            };

            Assert.IsFalse(this.calculator.Calc(inventoryDetails));
        }

        [Test]
        public void When_ListHas2ItensSuming0_Should_ReturnFalse()
        {
            IInventoryDetails inventoryDetails = new InventoryDetailsMock()
            {
                Quantity = 0,
                Warehouses = new List<IInventoryWarehouse>()
                {
                    new InventoryWarehouseMock() { Locality = "A", Quantity = 0, Type = "AA"},
                    new InventoryWarehouseMock() { Locality = "B", Quantity = 0, Type = "BB"},
                }
            };

            Assert.IsFalse(this.calculator.Calc(inventoryDetails));
        }

        [Test]
        public void When_ListHas2ItensSuming10_Should_ReturnTrue()
        {
            IInventoryDetails inventoryDetails = new InventoryDetailsMock()
            {
                Quantity = 10,
                Warehouses = new List<IInventoryWarehouse>()
                {
                    new InventoryWarehouseMock() { Locality = "A", Quantity = 9, Type = "AA"},
                    new InventoryWarehouseMock() { Locality = "B", Quantity = 1, Type = "BB"},
                }
            };

            Assert.IsTrue(this.calculator.Calc(inventoryDetails));
        }
    }
}
