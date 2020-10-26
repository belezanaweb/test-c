using Boticario.Backend.Modules.Inventory.Implementation.BusinessLogic;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Tests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.Tests
{
    public class DefaultQuantityInventoryCalculatorTests
    {
        private DefaultQuantityInventoryCalculator calculator;

        [SetUp]
        public void Setup()
        {
            this.calculator = new DefaultQuantityInventoryCalculator();
        }

        [Test]
        public void When_ListIsEmpty_Should_Return0()
        {
            Assert.AreEqual(0, this.calculator.Calc(new List<IInventoryEntity>()));
        }

        [Test]
        public void When_ListHas2ItensSuming15_Should_Return15()
        {
            IList<IInventoryEntity> list = new List<IInventoryEntity>()
            {
                new InventoryEntityMock() { Locality ="A", Quantity = 10, Type = "AA"},
                new InventoryEntityMock() { Locality ="B", Quantity = 5, Type = "BB"}
            };

            Assert.AreEqual(15, this.calculator.Calc(list));
        }
    }
}
