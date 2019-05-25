using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BelezaNaWeb;
using BelezaNaWeb.Controllers;
using BelezaNaWeb.Data;
using BelezaNaWeb.Models;
using BelezaNaWeb.CustomException;

namespace BelezaNaWeb.Tests.Controllers
{
    [TestClass]
    public class ProductDataTest
    {
        [TestMethod]
        public void GetProducts()
        {
            ProductsData controller = new ProductsData();

            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            controller.Add(new ProductModel(1, "teste", new InventoryModel(warehouseList)));
            controller.Add(new ProductModel(2, "outro", new InventoryModel(warehouseList)));

            List<ProductModel> result = controller.GetProducts();
            
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetProductById()
        {
            ProductsData controller = new ProductsData();

            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            ProductModel prod = new ProductModel(4, "teste", new InventoryModel(warehouseList));
            controller.Add(prod);

            ProductModel result = controller.GetProductBySKU(4);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(prod, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException),
            "Produto não encontrado")]
        public void GetProductByIdFail()
        {
            ProductsData controller = new ProductsData();

            ProductModel result = controller.GetProductBySKU(100);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddProduct()
        {
            ProductsData controller = new ProductsData();

            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            ProductModel prod = new ProductModel(3, "teste", new InventoryModel(warehouseList));
            controller.Add(prod);

            ProductModel result = controller.GetProductBySKU(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(prod, result);
        }

        [TestMethod]
        public void ModifyProduct()
        {
            ProductsData controller = new ProductsData();

            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            ProductModel prod = new ProductModel(5, "teste", new InventoryModel(warehouseList));
            controller.Add(prod);

            prod.name = "teste modificado";
            controller.ModifyProduct(5, prod);

            ProductModel result = controller.GetProductBySKU(5);

            Assert.IsNotNull(result);
            Assert.AreEqual("teste modificado", result.name);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException),
            "Produto não encontrado")]
        public void RemoveProduct()
        {
            ProductsData controller = new ProductsData();

            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            warehouseList.Add(new WarehouseModel("SP", 5, "WEB"));
            controller.Add(new ProductModel(6, "teste", new InventoryModel(warehouseList)));
            controller.RemoveProduct(6);

            ProductModel result = controller.GetProductBySKU(6);
        }
    }
}
