using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

//Fiz testes basicos sem o package MOQ pela simplicidade dos testes
namespace GBTest.ALC.UnitTests
{
    [TestClass]
    public class BasicUnitTest
    {

        [TestMethod]
        public void TestAddProducts()
        {
            try
            {
                Setup();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetBySku()
        {
            Setup();
            var item = _productController.Get("A00001");
            Assert.IsNotNull(item);
            Assert.AreEqual("A00001",item.Sku);
        }

        [TestMethod]
        public void TestGetAll()
        {
            Setup();
            var items = _productController.Get();
            Assert.AreEqual(3, items.Count);
        }

        [TestMethod]
        public void TestDuplicatedData()
        {
            try
            {
                Setup();
                _productController.Post(_products.FirstOrDefault());
                Assert.Fail("Duplicated Data.");
            }
            catch
            {
                return;
            }
        }

        [TestMethod]
        public void TestUpdateData()
        {
            Setup();
            var item = _products.FirstOrDefault();
            item.Name = "Teste";
            _productController.Update(item);
            var editedItem = _productController.Get(item.Sku);
            Assert.AreEqual(item.Name, editedItem.Name);

        }

        [TestMethod]
        public void TestRemoveData()
        {
            Setup();
            var items = _productController.Get();
            var qty = items.Count;
            _productController.Delete(items.FirstOrDefault());
            var newQty = _productController.Get().Count;
            Assert.AreEqual(qty-1, newQty);
        }

        private Infra.Data.Local.Repositories.ProductRepository _productRepository;
        private Domain.Services.ProductService _productService;
        private WebAPI.Controllers.ProductController _productController;
        private List<Domain.Entities.Product> _products;
        private void Setup()
        {
            if (_productRepository !=null)
                return;

            _productRepository = new Infra.Data.Local.Repositories.ProductRepository();
            _productService = new Domain.Services.ProductService(_productRepository);
            _productController = new WebAPI.Controllers.ProductController(_productService);
            _products = new List<Domain.Entities.Product>()
            {
                new Domain.Entities.Product()
                {
                    Sku = "A00001",
                    Name = "Malbec Desodorante Colônia 100ml",
                    Inventory = new Domain.Entities.Inventory()
                    {
                        new Domain.Entities.InventoryItem()
                        {
                            WareHouses = new Domain.Entities.Warehouses()
                            {
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "SP",
                                    Quantity = 15M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "RJ",
                                    Quantity = 10M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "MG",
                                    Quantity = 150M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.PHYSICAL_STORE
                                }
                            }
                        }
                    }
                },
                new Domain.Entities.Product()
                {
                    Sku = "A00002",
                    Name = "Quasar Graffiti Desodorante Colônia 100ml",
                    Inventory = new Domain.Entities.Inventory()
                    {
                        new Domain.Entities.InventoryItem()
                        {
                            WareHouses = new Domain.Entities.Warehouses()
                            {
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "SP",
                                    Quantity = 150M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "RJ",
                                    Quantity = 10M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "MG",
                                    Quantity = 1M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.PHYSICAL_STORE
                                }
                            }
                        }
                    }
                },
                new Domain.Entities.Product()
                {
                    Sku = "A00003",
                    Name = "Refil Desodorante Body Spray Quasar Surf 100 ml",
                    Inventory = new Domain.Entities.Inventory()
                    {
                        new Domain.Entities.InventoryItem()
                        {
                            WareHouses = new Domain.Entities.Warehouses()
                            {
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "SP",
                                    Quantity = 10M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "RJ",
                                    Quantity = 0M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.ECOMMERCE
                                },
                                new Domain.Entities.Warehouse()
                                {
                                    Locality = "MG",
                                    Quantity = 200M,
                                    Type = Domain.Entities.Warehouse.WarehouseType.PHYSICAL_STORE
                                }
                            }
                        }
                    }
                }
            };

            _products.ForEach(prod =>
            {
                _productController.Post(prod);
            });

        }
    }

}