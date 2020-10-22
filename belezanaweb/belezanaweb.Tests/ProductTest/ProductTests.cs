using belezanaweb.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace belezanaweb.Tests.ProductTest
{
    [TestClass]
    public class ProductTests
    {

        private Product _product;
        private Inventory _inventory;
        private Warehouse _warehouse;

        public ProductTests()
        {
            _product = new Product();
            _inventory = new Inventory();
            _warehouse = new Warehouse();
            _product.Inventory = _inventory;            
        }
                   
        [TestMethod]
        public void VerifyInventoryQuantity()
        {           
            _inventory.Warehouses.Add(new Warehouse() { Quantity = 5 });
            _inventory.Warehouses.Add(new Warehouse() { Quantity = 2 });
            _inventory.Warehouses.Add(new Warehouse() { Quantity = 0 });

            Assert.AreEqual(7, _product.Inventory.Quantity);
            Assert.AreEqual(_product.Inventory.Quantity, _inventory.Quantity);            
        }

        [TestMethod]
        public void VerifyIfProductIsMarketable()
        {           
            _inventory.Warehouses.Add(new Warehouse() { Quantity = 0 });
            Assert.IsFalse(_product.IsMarketable);

            _inventory.Warehouses.Add(new Warehouse() { Quantity = 2 });
            Assert.IsTrue(_product.IsMarketable);
        }
    }
}
