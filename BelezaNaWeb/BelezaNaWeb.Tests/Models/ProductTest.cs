using BelezaNaWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Tests.Controllers
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetQuantity()
        {
            List<WarehouseModel> warehouses = new List<WarehouseModel>();
            warehouses.Add(new WarehouseModel("SP", 3, "WEB"));
            warehouses.Add(new WarehouseModel("RJ", 5, "WEB"));
            InventoryModel inventory = new InventoryModel(warehouses);
            ProductModel product = new ProductModel(1, "test quantity", inventory);

            int result = product.inventory.quantity;

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void IsMarketable()
        {
            List<WarehouseModel> warehouses = new List<WarehouseModel>();
            warehouses.Add(new WarehouseModel("SP", 3, "WEB"));
            warehouses.Add(new WarehouseModel("RJ", 5, "WEB"));
            InventoryModel inventory = new InventoryModel(warehouses);
            ProductModel product = new ProductModel(1, "test quantity", inventory);

            bool result = product.isMarketable;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetZeroQuantity()
        {
            List<WarehouseModel> warehouses = new List<WarehouseModel>();
            InventoryModel inventory = new InventoryModel(warehouses);
            ProductModel product = new ProductModel(1, "test quantity", inventory);

            int result = product.inventory.quantity;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void IsMarketableFalse()
        {
            List<WarehouseModel> warehouses = new List<WarehouseModel>();
            InventoryModel inventory = new InventoryModel(warehouses);
            ProductModel product = new ProductModel(1, "test quantity", inventory);

            bool result = product.isMarketable;

            Assert.IsFalse(result);
        }
    }
}
