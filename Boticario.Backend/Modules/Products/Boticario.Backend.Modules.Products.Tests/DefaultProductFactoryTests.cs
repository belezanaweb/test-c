using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Implementation.Factories;
using Boticario.Backend.Modules.Products.Models;
using Boticario.Backend.Modules.Products.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Tests
{
    public class DefaultProductFactoryTests
    {
        private DefaultProductFactory productFactory;

        [SetUp]
        public void Setup()
        {
            this.productFactory = new DefaultProductFactory();
        }

        [Test]
        public void When_SkuIsLessThan1_Should_ThrowException()
        {
            Exception exception = Assert.Throws<ProductValidationException>(() =>
            {
                this.productFactory.CreateEntity(0, "Abc");
            });

            Assert.AreEqual("SKU is invalid!", exception.Message);
        }

        [Test]
        public void When_NameIsEmptyOrNull_Should_ThrowException()
        {
            Exception exception = Assert.Throws<ProductValidationException>(() =>
            {
                this.productFactory.CreateEntity(1, string.Empty);
            });

            Assert.AreEqual("Name is missing!", exception.Message);
        }

        [Test]
        public void When_ParametersAreValid_Should_ReturnObject()
        {
            IProductEntity product = this.productFactory.CreateEntity(1, "Abc");
         
            Assert.AreEqual(1, product.Sku);
            Assert.AreEqual("Abc", product.Name);
        }

        [Test]
        public void When_NameHasExtraSpaces_Should_ReturnNameTrimed()
        {
            IProductEntity product = this.productFactory.CreateEntity(1, " Abc ");

            Assert.AreEqual("Abc", product.Name);
        }

        [Test]
        public void When_CreateDetailsObject_Should_ReturnSameValuesInformed()
        {
            IProductEntity entity = new ProductEntityMock() { Sku = 1, Name = "Abc" };

            IInventoryDetails inventoryDetails = new InventoryDetailsMock()
            {
                Quantity = 30,
                Warehouses = new List<IInventoryWarehouse>() {
                    new InventoryWarehouseMock() { Locality = "A", Quantity = 10, Type = "AA" },
                    new InventoryWarehouseMock() { Locality = "B", Quantity = 20, Type = "BB" }
                }
            };

            IProductDetails product = this.productFactory.CreateDetails(entity, inventoryDetails);

            Assert.AreEqual(1, product.Sku);
            Assert.AreEqual("Abc", product.Name);

            Assert.IsTrue(product.IsMarketable);

            Assert.AreEqual("A", product.Inventory.Warehouses[0].Locality);
            Assert.AreEqual(10, product.Inventory.Warehouses[0].Quantity);
            Assert.AreEqual("AA", product.Inventory.Warehouses[0].Type);

            Assert.AreEqual("B", product.Inventory.Warehouses[1].Locality);
            Assert.AreEqual(20, product.Inventory.Warehouses[1].Quantity);
            Assert.AreEqual("BB", product.Inventory.Warehouses[1].Type);
        }
    }
}