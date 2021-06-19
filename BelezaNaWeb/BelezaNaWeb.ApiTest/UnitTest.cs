using System.Collections.Generic;
using BelezaNaWeb.Api.Model.Entities;
using NUnit.Framework;

namespace BelezaNaWeb.ApiTest
{
    [TestFixture]
    public class Tests
    {
        private Product _productWithInventory;
        private Product _productWithoutInventory;
        
        [SetUp]
        public void Setup()
        {
            _productWithInventory = new Product
            {
                Sku = 43265,
                Name = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43266,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse()
                        { 
                            Sku = 43267, 
                            Locality = "SP", 
                            Quantity = 12, 
                            Type = "ECOMMERCE" 
                        },
                        new Warehouse()
                        { 
                            Sku = 43268, 
                            Locality = "MOEMA", 
                            Quantity = 3, 
                            Type = "PHYSICAL_STORE" 
                        }
                    }
                }
            };

            _productWithoutInventory = new Product
            {
                Sku = 123456,
                Name = "Arbo Desodorante Colônia 100ml",
                Inventory = new Inventory()
                {
                    Sku = 654321,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse()
                        { 
                            Sku = 456789, 
                            Locality = "SERRA", 
                            Quantity = 0, 
                            Type = "TEST_TYPE" 
                        }
                    }
                }
            };
        }

        [Test]
        public void ShouldBeMarketable()
        {
            var result = _productWithInventory.IsMarketable;
            Assert.IsTrue(result, "should be marketable");
        }

        [Test]
        public void InventoryShouldHaveQuantity()
        {
            var result = _productWithInventory.Inventory.Quantity;
            int expect = 15;
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ShouldNotBeMarketable()
        {
            var result = _productWithoutInventory.IsMarketable;
            Assert.IsFalse(result, "should not be marketable");
        }

        [Test]
        public void InventoryQuantityShouldBeZero()
        {
            var result = _productWithoutInventory.Inventory.Quantity;
            int expect = 0;
            Assert.AreEqual(expect, result);
        }
        
    }
}
