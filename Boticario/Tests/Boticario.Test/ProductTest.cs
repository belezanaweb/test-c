using Boticario.Domain.Entities;
using Boticario.Domain.Services;
using Boticario.Reporitory.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace Boticario.Test
{
    public class ProductTest
    {
        public Product Product { get; set; }

        private ProductService _productServices;

        [SetUp]
        public void Setup()
        {
            Product = new Product(43265, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 700g") { Inventory = new Inventory() };

            _productServices = new ProductService(new ProductRepository());
        }

        [Test]
        public void VerifyIsMarketableEqualToZero()
        {
            Product.Inventory.Warehouses = new List<Warehouse> { new Warehouse() };

            Assert.AreEqual(Product.Inventory.Quantity, 0);
        }

        [Test]
        public void VerifyProductWithStockIsMarketable()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("POMPEIA", 12, "ECOMMERCE"),
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            };

            Assert.IsTrue(Product.IsMarketable);
        }

        [Test]
        public void VerifyQuantityOfProductInStockIsGreaterOrEqualOne()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("POMPEIA", 12, "ECOMMERCE"),
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            };

            Assert.GreaterOrEqual(Product.Inventory.Quantity, 1);
        }

        [Test]
        public void VerifyGetProductBySku()
        {
            var result = _productServices.GetProductBySku(43264);
            Assert.AreEqual(result.Sku, 43264);
        }

        [Test]
        public void VerifyAddProductAndInventoryWarehouses()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            };

            var result = _productServices.Add(Product);

            Assert.AreEqual(result.Sku, 43265);
            Assert.GreaterOrEqual(result.Inventory.Quantity, 1);
        }

        [Test]
        public void VerifyUpdateInventoryWarehouseProduct()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            };

            var resultAdd = _productServices.Add(Product);
            Assert.AreEqual(resultAdd.Inventory.Quantity, 3);

            Product.Inventory.Warehouses.Add(new Warehouse("POMPEIA", 12, "ECOMMERCE"));

            var resultUpdate = _productServices.Update(Product);

            Assert.AreEqual(resultUpdate.Sku, 43265);
            Assert.AreEqual(resultUpdate.Inventory.Quantity, 15);
        }

        [Test]
        public void VerifyDeleteProductAndInventoryWarehouses()
        {
            Product.Inventory.Warehouses = new List<Warehouse>
                                            {
                                                new Warehouse("MOEMA", 3, "PHYSICAL_STORE")
                                            };

            var resultAdd = _productServices.Add(Product);

            Assert.AreEqual(resultAdd.Sku, 43265);

            var resultDelete = _productServices.Delete(43265);
            Assert.IsTrue(resultDelete);
        }
    }
}