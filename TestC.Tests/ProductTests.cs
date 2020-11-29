using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Xunit;

using TestC.ExceptionHandler;
using TestC.Models;
using TestC.Repositories;
using TestC.Services;

namespace TestC.Tests
{
    public class ProductServiceTest
    {
        protected readonly ProductService _service;

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 
                new Product()
                {
                    sku = 1,
                    name = "Product Test One",
                    inventory = new Inventory()
                    {
                        warehouses = new List<Warehouse>
                        {
                            new Warehouse() { locality = "LOCALITY 1", quantity = 4, type = "ECOMMERCE" },
                            new Warehouse() { locality = "LOCALITY 2", quantity = 1, type = "PHYSICAL_STORE" },
                        }
                    }
                }
            };
            yield return new object[] { 
                new Product()
                {
                    sku = 2,
                    name = "Product Test Two",
                    inventory = new Inventory()
                    {
                        warehouses = new List<Warehouse>
                        {
                            new Warehouse() { locality = "LOCALITY 2", quantity = 12, type = "ECOMMERCE" },
                        }
                    }
                }
             };
            yield return new object[] { 
                new Product()
                {
                    sku = 3,
                    name = "Product Test Three",
                    inventory = new Inventory()
                    {
                        warehouses = new List<Warehouse>
                        {
                            new Warehouse() { locality = "LOCALITY 1", quantity = 0, type = "PHYSICAL_STORE" },
                        }
                    }
                }
             };
        }

        public ProductServiceTest()
        {
            var mockRepo = new Mock<IBaseRepository<Product>>();
            var testDataList = TestData().Select(item => (Product)item[0]).ToList();

            mockRepo.Setup(repo => repo.GetAll()).Returns(testDataList);

            mockRepo.Setup(repo => repo.GetByID(It.IsAny<int>())).Returns((int sku) =>    
                testDataList.SingleOrDefault(p => p.sku == sku));

            mockRepo.Setup(repo => repo.Insert(It.IsAny<Product>()))
                .Callback((Product product) =>
                {
                    testDataList.Add(product);
                });

            mockRepo.Setup(repo => repo.Update(It.IsAny<Product>()))
                .Returns((Product product) =>
                {
                    int index = testDataList.FindIndex(p => p.sku == product.sku);
                    
                    if (index >= 0) {
                        testDataList[index] = product;
                        return product;
                    }

                    return null;
                });

            mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .Callback((int sku) =>
                {
                    int index = testDataList.FindIndex(p => p.sku == sku);
                    testDataList.RemoveAt(index);
                }).Verifiable();

            mockRepo.SetupAllProperties();

            _service = new ProductService(mockRepo.Object);
        }

        [Fact]
        public void TestSimpleInsert()
        {
            int sku = 43264;
            var product = new Product()
            {
                sku = sku,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g"
            };
            product.inventory.warehouses.AddRange(new Warehouse[] {
                new Warehouse() { locality = "SP", quantity = 4, type = "ECOMMERCE" },
            });


            _service.Insert(product);

            Assert.True(_service.GetAll().FirstOrDefault(p => p.sku == sku) != null);
        }

        [Fact]
        public void TestInsertWithUsedSKU_throwException()
        {
            int sku = 1;
            var product = new Product()
            {
                sku = sku,
                name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g"
            };
            product.inventory.warehouses.AddRange(new Warehouse[] {
                new Warehouse() { locality = "SP", quantity = 4, type = "ECOMMERCE" },
            });

            Assert.Throws<HttpResponseException>(() => _service.Insert(product));
        }

        [Fact]
        public void TestProductUpdate()
        {
            int sku = 1;
            string name = "Updated Product";

            var product = new Product()
            {
                sku = sku,
                name = name
            };
            product.inventory.warehouses.AddRange(new Warehouse[] {
                new Warehouse() { locality = "LOCALITY 1", quantity = 0, type = "ECOMMERCE" }
            });

            _service.Update(product);

            Assert.Equal(name, _service.GetByID(sku).name);
        }

        [Fact]
        public void GetProductBySKU()
        {
            int sku = 1;
            Product product = _service.GetByID(sku);
            Assert.Equal(sku, product.sku);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AssureQuantity(Product product)
        {
            Assert.Equal(product.inventory.quantity, product.inventory.warehouses.Sum(w => w.quantity));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AssureIsMarketable(Product product)
        {
            Assert.Equal(product.isMarketable, product.inventory.quantity > 0);
        }
        
        [Fact]
        public void RemoveProductBySKU()
        {
            int currentCount = _service.GetAll().Count();
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            _service.Delete(1);

            Assert.Equal(_service.GetAll().Count(), currentCount -1);
        }

        [Fact]
        public void RemoveProductByNonExistingSKU_throwException()
        {
            Assert.Throws<HttpResponseException>(() => _service.Delete(999));
        }
    }
}
