using System;
using System.Collections.Generic;
using System.Text;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using NUnit;
using NUnit.Framework;

namespace BelezaNaWebAPITests
{
    [TestFixture]
    public class UnitProductTest
    {
        private IProductRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new ProductRepository();
        }

        [Test]
        public void GetProducts()
        {
            _repository.Create(new ProductModel { Sku = 1 });
            _repository.Create(new ProductModel { Sku = 2 });
            _repository.Create(new ProductModel { Sku = 3 });

            var products = _repository.GetAll();

            Assert.IsNotNull(products);
        }

        [Test]
        public void GetProductBySkuSuccess()
        {
            _repository.Create(new ProductModel { Sku = 1 });

            var product = _repository.GetBySku(1);

            Assert.IsNotNull(product);
        }

        [Test]
        public void GetProductBySkuFailure()
        {
            Assert.Throws(Is.TypeOf<ProductException>().And.Message.EqualTo("Product not found"), delegate
            {
                _repository.GetBySku(1);
            });
        }

        [Test]
        public void CreateSuccess()
        {
            ProductModel product = new ProductModel();
            var createSuccess = _repository.Create(product);
            Assert.True(createSuccess, "Product successfully created");
        }

        [Test]
        public void CreateFailure()
        {
            _repository.Create(new ProductModel { Sku = 1 });
            _repository.Create(new ProductModel { Sku = 2 });

            Assert.Throws(Is.TypeOf<ProductException>().And.Message.EqualTo("Sku already exists in the repository"), delegate
            {
                _repository.Create(new ProductModel { Sku = 1 });
            });
        }

        [Test]
        public void UpdateSuccess()
        {
            _repository.Create(new ProductModel { Sku = 1 });
            var product = new ProductModel { Sku = 1, Name = "Name Test" };
            var result = _repository.Update(1, product);

            Assert.IsTrue(result, "Product successfully changed");
        }

        [Test]
        public void UpdateFailure()
        {
            var product = new ProductModel { Sku = 1, Name = "Name Test" };
            Assert.Throws(Is.TypeOf<ProductException>().And.Message.EqualTo("Product not found"), delegate
            {
                _repository.Update(-1, product);
            });
        }

        [Test]
        public void DeleteSuccess()
        {
            _repository.Create(new ProductModel { Sku = 1 });
            var result = _repository.Delete(1);
            Assert.IsTrue(result, "Product successfully deleted");
        }

        [Test]
        public void DeleteFailure()
        {
            Assert.Throws(Is.TypeOf<ProductException>().And.Message.EqualTo("Product not found"), delegate
            {
                _repository.Delete(1);
            });
        }

        [Test]
        public void QuantityTest()
        {
            _repository.Create(new ProductModel
            {
                Sku = 1,
                Inventory = new InventoryModel
                {
                    Warehouses = new List<WarehouseModel>{
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 10,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 15,
                            Type = "ECOMMERCE"
                        },
                    }
                }
            });

            var product = _repository.GetBySku(1);

            Assert.AreEqual(25, product.Inventory.Quantity);
        }

        [Test]
        public void IsMarketableTrue()
        {
            _repository.Create(new ProductModel
            {
                Sku = 1,
                Inventory = new InventoryModel
                {
                    Warehouses = new List<WarehouseModel>{
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 10,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 15,
                            Type = "ECOMMERCE"
                        },
                    }
                }
            });

            var product = _repository.GetBySku(1);

            Assert.IsTrue(product.IsMarketable);
        }

        [Test]
        public void IsMarketableFalse()
        {
            _repository.Create(new ProductModel
            {
                Sku = 1,
                Inventory = new InventoryModel
                {
                    Warehouses = new List<WarehouseModel>{
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 0,
                            Type = "ECOMMERCE"
                        },
                        new WarehouseModel
                        {
                            Locality = "SP",
                            Quantity = 0,
                            Type = "ECOMMERCE"
                        },
                    }
                }
            });

            var product = _repository.GetBySku(1);

            Assert.IsFalse(product.IsMarketable);
        }
    }
}
