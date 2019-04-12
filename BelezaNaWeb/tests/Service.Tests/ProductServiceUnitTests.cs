using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Model.Interfaces.Services;
using Model.Models;
using Moq;
using NUnit.Framework;

namespace Service.Tests
{
    public class ProductServiceUnitTests
    {
        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();
        
        private IProductService _productService;

        private List<Product> _productsRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _productsRepositoryMock = new List<Product> {
                new Product
                {
                    Sku = 43264,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Inventory = new Inventory
                    {
                        Quantity = 15,
                        Warehouses = new List<Warehouse> {
                            new Warehouse { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                            new Warehouse { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                        }
                    },
                    IsMarketable = true
                },
                new Product
                {
                    Sku = 43265,
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 250g",
                    Inventory = new Inventory
                    {
                        Quantity = 0,
                        Warehouses = new List<Warehouse> {
                            new Warehouse { Locality = "SP", Quantity = 0, Type = "ECOMMERCE" },
                            new Warehouse { Locality = "MOEMA", Quantity = 0, Type = "PHYSICAL_STORE" }
                        }
                    },
                    IsMarketable = false
                }
            };
            _productService = _productServiceMock.Object;
        }

        [Test]
        public void GetBySkuId_WhenRetrieved_ShouldCalculateInventoryQuantity()
        {
            // Arrange
            var productSkuId = 43264;
            var product = _productsRepositoryMock[0];
            var expectedResult = product.Inventory.Warehouses.Sum(_ => _.Quantity);

            _productServiceMock.Setup(_ => _.Get(productSkuId))
                .Returns(_productsRepositoryMock[0]);

            // Act
            var result = _productService.Get(productSkuId);

            // Assert
            result.Inventory.Quantity.Should().Be(expectedResult);
        }

        public static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(0, true);
            yield return new TestCaseData(1, false);
        }

        [TestCaseSource(nameof(TestCases))]
        public void GetBySkuId_AccordingToInventoryQuantity_ShouldSetIsMarketable(int productIndex, bool expectedResult)
        {
            // Arrange
            _productServiceMock.Setup(_ => _.Get(It.IsAny<int>()))
                .Returns(_productsRepositoryMock[productIndex]);

            // Act
            var result = _productService.Get(1);

            // Assert
            result.IsMarketable.Should().Be(expectedResult);
        }

        [Test]
        public void Add_WhenSkuAlreadyExists_ShouldThrowAnException()
        {
            // Arrange
            var product = new Product { Sku = 43264 }; //_productsRepository[0];
            
            _productServiceMock.Setup(_ => _.Add(product))
                .Throws(new Exception());

            // Act & Assert
            Assert.That(() => _productService.Add(product), 
                Throws.Exception.TypeOf<Exception>());
        }

        [Test]
        public void Update_WhenProductDoesNotExist_ShouldThrowAnException()
        {
            // Arrange
            var product = new Product { Sku = 43264 }; //_productsRepository[0];
            
            _productServiceMock.Setup(_ => _.Update(product))
                .Throws(new Exception());

            // Act & Assert
            Assert.That(() => _productService.Update(product), 
                Throws.Exception.TypeOf<Exception>());
        }

        [Test]
        public void Update_WhenCalled_ShouldOverwriteExistentProduct()
        {
            // Arrange
            var product = new Product { Sku = 43264 };
            _productServiceMock.Setup(_ => _.Update(It.IsAny<Product>()));
            
            // Act & Assert
            Assert.DoesNotThrow(() => _productService.Update(product));
        }

        [Test]
        public void Delete_ShouldRemoveProduct()
        {
            // Arrange 
            _productServiceMock.Setup(_ => _.Delete(It.IsAny<int>()));

            // Act & Assert
            Assert.DoesNotThrow(() => _productService.Delete(1234));
        }
    }
}
