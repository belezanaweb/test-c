using BelezaNaWeb.TestC.Api.Controllers;
using BelezaNaWeb.TestC.Api.Data;
using BelezaNaWeb.TestC.Api.Exceptions;
using BelezaNaWeb.TestC.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BelezaNaWeb.TestC.Api.Tests.Controllers
{
    public class ProductControllerTest
    {
        private Mock<IProductDao> productDaoMock;
        private ProductController productController;

        public ProductControllerTest()
        {
            productDaoMock = new Mock<IProductDao>();
            productController = new ProductController(productDaoMock.Object);
        }

        #region Get

        [Fact]
        public void Get_SkuExists_ReturnProduct()
        {
            // Arrange
            var product = new Product { Sku = 1, Name = "Nome teste", Inventory = null };
            productDaoMock.Setup(p => p.Get(1)).Returns(product);

            // Act
            var result = productController.Get(1);

            // Assert
            Assert.IsType<ActionResult<Product>>(result);
            Assert.Equal(result.Value, product);
        }

        [Fact]
        public void Get_SkuDontExists_NotFound()
        {
            // Arrange
            productDaoMock.Setup(p => p.Get(It.IsAny<uint>())).Returns<Product>(null);

            // Act
            var result = productController.Get(1);

            // Assert
            Assert.IsType<ActionResult<Product>>(result);
            Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Null(result.Value);
        }

        #endregion

        #region Post

        [Fact]
        public void Post_ProductValid_Success()
        {
            // Arrange
            var productValid = new Product { Sku = 1, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Post(productValid);

            // Assert
            Assert.IsType<OkResult>(result);
            productDaoMock.Verify(p => p.Add(productValid), Times.Once());
        }

        [Fact]
        public void Post_ProductInvalid_BadRequest()
        {
            // Arrange
            var productInvalid = new Product { Sku = 0, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Post(productInvalid);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            productDaoMock.Verify(p => p.Add(productInvalid), Times.Never());
        }

        [Fact]
        public void Post_ProductAlreadyExists_BadRequest()
        {
            // Arrange
            var exception = new ObjetoJaExistenteNoBDException(string.Empty);
            productDaoMock.Setup(p => p.Add(It.IsAny<Product>())).Throws(exception);
            var productRepeated = new Product { Sku = 1, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Post(productRepeated);

            // Assert
            var resultBadRequest = Assert.IsType<BadRequestObjectResult>(result);
            productDaoMock.Verify(p => p.Add(productRepeated), Times.Once());
        }

        #endregion

        #region Put

        [Fact]
        public void Put_ProductValid_Success()
        {
            // Arrange
            var productValid = new Product { Sku = 2, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Put(1, productValid);

            // Assert
            Assert.IsType<OkResult>(result);
            productDaoMock.Verify(p => p.Edit(1, productValid), Times.Once());
        }

        [Fact]
        public void Put_ProductInvalid_BadRequest()
        {
            // Arrange
            var productInvalid = new Product { Sku = 0, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Put(1, productInvalid);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            productDaoMock.Verify(p => p.Edit(1, productInvalid), Times.Never());
        }

        [Fact]
        public void Put_ProductDontExists_BadRequest()
        {
            // Arrange
            var exception = new ObjetoNaoEncontradoNoBDException(string.Empty);
            productDaoMock.Setup(p => p.Edit(1, It.IsAny<Product>())).Throws(exception);
            var productNonExistent = new Product { Sku = 1, Name = "Nome do produto", Inventory = new Inventory() };

            // Act
            var result = productController.Put(1, productNonExistent);

            // Assert
            var resultBadRequest = Assert.IsType<BadRequestObjectResult>(result);
            productDaoMock.Verify(p => p.Edit(1, productNonExistent), Times.Once());
        }

        #endregion

        #region Delete

        [Fact]
        public void Delete_ProductExists_Success()
        {
            // Act
            var result = productController.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            productDaoMock.Verify(p => p.Delete(1), Times.Once());
        }
        
        [Fact]
        public void Delete_ProductDontExists_BadRequest()
        {
            // Arrange
            productDaoMock.Setup(p => p.Delete(1)).Throws(new ObjetoNaoEncontradoNoBDException(String.Empty));

            // Act
            var result = productController.Delete(1);

            // Assert
            var resultBadRequest = Assert.IsType<BadRequestObjectResult>(result);
            productDaoMock.Verify(p => p.Delete(1), Times.Once());
        }

        #endregion
    }
}
