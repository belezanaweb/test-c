using BelezaNaNet.Api.Models;
using BelezaNaNet.Api.ValueObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaNet.Testes
{
    public class Tests
    {
        [Test]
        public void QuantityShouldBe15()
        {
            var firstWarehouse = new Warehouse("SP", 10, "ECOMMERCE");
            var secondWarehouse = new Warehouse("MOEMA", 5, "PHYSICAL_STORE");
            var warehouses = new List<Warehouse>() { firstWarehouse, secondWarehouse };

            var inventory = new Inventory(warehouses);

            Assert.AreEqual(inventory.Quantity, warehouses.Sum(p => p.Quantity));
        }
        [Test]
        public void ProductShouldBeMarketable()
        {
            var firstWarehouse = new Warehouse("SP", 1, "ECOMMERCE");
            var warehouses = new List<Warehouse>() { firstWarehouse };

            var inventory = new Inventory(warehouses);
            var product = new Product(43562, "Shampoo", inventory);
            Assert.AreEqual(product.IsMarketable, true);
        }
        [Test]
        public void ProductShouldNotBeMarketable()
        {
            var firstWarehouse = new Warehouse("SP", 0, "ECOMMERCE");
            var warehouses = new List<Warehouse>() { firstWarehouse };

            var inventory = new Inventory(warehouses);
            var product = new Product(43562, "Shampoo", inventory);
            Assert.AreEqual(product.IsMarketable, false);
        }
    }
}