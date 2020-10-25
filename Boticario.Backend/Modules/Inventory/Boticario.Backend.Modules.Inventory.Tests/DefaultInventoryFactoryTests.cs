using Boticario.Backend.Modules.Inventory.Implementation.Exceptions;
using Boticario.Backend.Modules.Inventory.Implementation.Factories;
using Boticario.Backend.Modules.Inventory.Models;
using NUnit.Framework;
using System;

namespace Boticario.Backend.Modules.Inventory.Tests
{
    public class DefaultInventoryFactoryTests
    {
        private DefaultInventoryFactory inventoryFactory;

        [SetUp]
        public void Setup()
        {
            this.inventoryFactory = new DefaultInventoryFactory();
        }

        [Test]
        public void When_LocalityIsEmptyOrNull_Should_ThrowException()
        {
            Exception exception = Assert.Throws<InventoryValidationException>(() =>
            {
                this.inventoryFactory.Create(string.Empty, 1, "Abc");
            });

            Assert.AreEqual("Locality is missing!", exception.Message);
        }

        [Test]
        public void When_QuantityIsLessThanZero_Should_ThrowException()
        {
            Exception exception = Assert.Throws<InventoryValidationException>(() =>
            {
                this.inventoryFactory.Create("Abc", -1, "Abc");
            });

            Assert.AreEqual("Quantity is invalid!", exception.Message);
        }

        [Test]
        public void When_TypeIsEmptyOrNull_Should_ThrowException()
        {
            Exception exception = Assert.Throws<InventoryValidationException>(() =>
            {
                this.inventoryFactory.Create("Abc", 1, string.Empty);
            });

            Assert.AreEqual("Type is missing!", exception.Message);
        }

        [Test]
        public void When_ParametersAreValid_Should_ReturnObject()
        {
            IInventoryEntity inventory = this.inventoryFactory.Create("Abc", 1, "Def");

            Assert.AreEqual("Abc", inventory.Locality);
            Assert.AreEqual(1, inventory.Quantity);
            Assert.AreEqual("Def", inventory.Type);
        }

        [Test]
        public void When_LocalityHasExtraSpaces_Should_ReturnLocalityTrimed()
        {
            IInventoryEntity inventory = this.inventoryFactory.Create(" Abc ", 1, "Def");

            Assert.AreEqual("Abc", inventory.Locality);
        }

        [Test]
        public void When_TypeHasExtraSpaces_Should_ReturnTypeTrimed()
        {
            IInventoryEntity inventory = this.inventoryFactory.Create("Abc", 1, " Def ");

            Assert.AreEqual("Def", inventory.Type);
        }
    }
}