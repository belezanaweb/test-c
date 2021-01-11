using BNWTC.Api.Models.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace BNWTC.Tests
{
    [TestClass]
    public class UnitProductTest
    {
        [TestMethod]
        [TestCategory("Product")]
        public void TestIsMarketableTrueProduct()
        {
            var product = new Product
            {
                Id = 1,
                Sku = 43265,
                Name = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43265,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(true, product.IsMarketable);
        }

        [TestMethod]
        [TestCategory("Product")]
        public void TestIsMarketableFalseProduct()
        {
            var product = new Product
            {
                Id = 1,
                Sku = 43265,
                Name = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43265,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(false, product.IsMarketable);
        }


        [TestMethod]
        [TestCategory("Product")]
        public void TestCalculatedQuantityInvetary()
        {
            var product = new Product
            {
                Id = 1,
                Sku = 43265,
                Name = "Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    Sku = 43265,
                    Warehouses = new List<Warehouse>()
                    {
                        new Warehouse() { Id =1, Sku = 43265, Locality = "SP", Quantity = 6, Type = "ECOMMERCE" },
                        new Warehouse() { Id =2, Sku = 43265, Locality = "MOEMA", Quantity = 4, Type = "PHYSICAL_STORE" }
                    }
                }
            };

            Assert.AreEqual(10, product.Inventory.Quantity);
        }
    }
}
