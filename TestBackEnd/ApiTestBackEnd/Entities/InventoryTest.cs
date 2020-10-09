using BackendTest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTestBackEndTestWebApi.Entities
{
    [TestClass]
    public class InventoryTest
    {
        private readonly Inventory _inventory;

        public InventoryTest()
        {
            _inventory = new Inventory()
            {
                Id = 1               
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

        private int CalculateSumOfQuantityInWareHouseQuantityList(List<WareHouse> wareHouses)
        {
            return wareHouses.Sum(w => w.Quantity);
        }

        [TestMethod]
        public void QuantityMustBeSumOfWareHouseQuantityList()
        {
          
            _inventory.WareHouses = BuildListWareHouses();
            var quantity = CalculateSumOfQuantityInWareHouseQuantityList(_inventory.WareHouses);
            _inventory.CalculeteQuantity();
            Assert.AreEqual(quantity, _inventory.Quantity);
        }

        [TestMethod]
        public void QuantityMustBe0WhenListIsEmpty()
        {
            var quantity = 0;
            _inventory.CalculeteQuantity();
            Assert.AreEqual(quantity, _inventory.Quantity);
        }
    }
}
