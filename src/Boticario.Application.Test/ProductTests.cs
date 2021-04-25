using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Boticario.Application.Test
{
    public class ProductTests
    {
        #region Public Methods

        [Fact]
        public void Product_GetAll_Any()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);

            var productsFakeList = new List<Product>
            {
                NewProduct()
            };
            productRepository.Setup(x => x.GetAll()).Returns(productsFakeList);

            // Act
            var products = productApplication.GetAll();

            // Assert
            Assert.True(products.Any());
        }

        [Fact]
        public void Product_GetAll_Empty()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);

            // Act
            var products = productApplication.GetAll();

            // Assert
            Assert.Null(products);
        }

        [Fact]
        public void Product_GetBySku_Any()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake = NewProduct();
            productRepository.Setup(x => x.GetBySku(productFake.Sku)).Returns(productFake);

            // Act
            var products = productApplication.GetBySku(productFake.Sku);

            // Assert
            Assert.False(products is null);
        }

        [Fact]
        public void Product_GetBySku_Empty()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake = NewProduct();

            // Act
            var products = productApplication.GetBySku(productFake.Sku);

            // Assert
            Assert.True(products is null);
        }

        [Fact]
        public void Product_Create_Ok()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);

            var productFake = NewProduct();
            productRepository.Setup(x => x.Create(productFake)).Returns(productFake);

            // Act
            var product = productApplication.Create(productFake);

            // Assert
            Assert.Equal(product, productFake);
        }

        [Fact]
        public void Product_Create_Null()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake = NewProduct();

            // Act
            var product = productApplication.Create(productFake);

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public void Product_Update_Ok()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake1 = NewProduct();
            var productFake2 = productFake1;
            productFake2.Name = "Shampoo B";
            productRepository.Setup(x => x.Update(productFake2)).Returns(productFake2);

            // Act
            var product = productApplication.Update(productFake2);

            // Assert
            Assert.Equal(product, productFake2);
        }

        [Fact]
        public void Product_Update_Null()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake1 = NewProduct();
            var productFake2 = productFake1;
            productFake2.Name = "Shampoo B";

            // Act
            var product = productApplication.Update(productFake2);

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public void Product_Delete_Ok()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake = NewProduct();
            productRepository.Setup(x => x.DeleteBySku(productFake.Sku)).Returns(true);

            // Act
            var productResponse = productApplication.DeleteBySku(productFake.Sku);

            // Assert
            Assert.True(productResponse);
        }

        [Fact]
        public void Product_Delete_False()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var productRepository = new Mock<IProductRepository>();
            var productApplication = new ProductApplication(notificator.Object, productRepository.Object);
            var productFake = NewProduct();
            productRepository.Setup(x => x.DeleteBySku(productFake.Sku)).Returns(false);

            // Act
            var productResponse = productApplication.DeleteBySku(productFake.Sku);

            // Assert
            Assert.False(productResponse);
        }

        #endregion

        #region Private Methods

        private static Product NewProduct()
        {
            return new Product
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory
                {
                    Warehouses = new List<Warehouse> {
                        new Warehouse{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        new Warehouse{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        #endregion
    }
}