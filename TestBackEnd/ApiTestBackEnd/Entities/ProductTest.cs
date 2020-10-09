using BackendTest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProjectTestBackEndTestWebApi.Entities
{
    [TestClass]
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product()
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g"
            };
        }

        private List<WareHouse> BuildListWareHouses()
        {
            return new List<WareHouse>()
            {
               new WareHouse()
               {
                 Id = 1,
                 Locality = "SP",
                 Quantity= 12,
                 Type = "ECOMMERCE"
               },
               new WareHouse()
               {
                 Id = 2,
                 Locality = "MOEMA",
                 Quantity= 3,
                 Type = "PHYSICAL_STORE"
               }
            };
        }

        private Inventory BuildInventoty()
        {
            return new Inventory()
            {
                WareHouses = BuildListWareHouses()
            };
        }

        [TestMethod]
        public void IsMarketableMustBeTrueWhenQuantityGreaterThenZero()
        {
            _product.Inventory = BuildInventoty();
            _product.Inventory.CalculeteQuantity();
            _product.SetIsMarketable();
           Assert.IsTrue(_product.IsMarketable);
        }


        [TestMethod]
        public void IsMarketableMustBFalseWhenQuantityIsZero()
        {
            _product.SetIsMarketable();
            Assert.IsFalse(_product.IsMarketable);
        }
    }

}
