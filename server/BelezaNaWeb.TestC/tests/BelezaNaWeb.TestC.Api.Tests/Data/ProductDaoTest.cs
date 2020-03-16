using BelezaNaWeb.TestC.Api.Data;
using BelezaNaWeb.TestC.Api.Exceptions;
using BelezaNaWeb.TestC.Api.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BelezaNaWeb.TestC.Api.Tests.Data
{
    public class ProductDaoTest
    {
        private Mock<IBdInMemory> bdInMemory;
        private IList<Product> products;
        private ProductDao productDao;

        public ProductDaoTest()
        {
            bdInMemory = new Mock<IBdInMemory>();
            products = new List<Product>();
            bdInMemory.Setup(p => p.Products).Returns(products);
            productDao = new ProductDao(bdInMemory.Object);
        }

        #region Get

        [Fact]
        public void Get_ExistingProduct_Success()
        {
            // Arrange
            var product = new Product { Sku = 1, Name = "Nome teste", Inventory = new Inventory() };
            products.Add(product);

            // Act
            var result = productDao.Get(1);

            // Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public void Get_ProductDontExists_Null()
        {
            // Act
            var result = productDao.Get(1);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region Add

        [Fact]
        public void Add_NewProduct_Success()
        {
            // Arrange
            var product = new Product { Sku = 1, Name = "Nome teste", Inventory = new Inventory() };

            // Act
            productDao.Add(product);

            // Assert
            Assert.Contains(product, products);
        }
        
        [Fact]
        public void Add_ProductAlreadyExists_Throw()
        {
            // Arrange
            var newProduct = new Product { Sku = 1, Name = "Nome teste 1", Inventory = new Inventory() };
            var existingProduct = new Product { Sku = 1, Name = "Nome teste 2", Inventory = new Inventory() };
            products.Add(existingProduct);

            // Act, Assert
            Assert.Throws<ObjetoJaExistenteNoBDException>(
                () => productDao.Add(newProduct));

            // Assert
            Assert.Contains(existingProduct, products);
            Assert.DoesNotContain(newProduct, products);
        }

        #endregion

        #region Edit

        [Fact]
        public void Edit_Product_Success()
        {
            // Arrange
            var existingProducts = new List<Product>
            {
                new Product { Sku = 1, Name = "Nome teste 1", Inventory = new Inventory() },
                new Product { Sku = 2, Name = "Nome teste 2", Inventory = new Inventory() },
                new Product { Sku = 3, Name = "Nome teste 3", Inventory = new Inventory() },
            };
            var newProduct = new Product { Sku = 4, Name = "Nome teste 4", Inventory = new Inventory() };
            existingProducts.ForEach(p => products.Add(p));

            // Act
            productDao.Edit(2, newProduct);

            // Assert
            Assert.Equal(3, products.Count);
            Assert.Equal(newProduct, products[1]);
        }
        
        [Fact]
        public void Edit_ProductDontExists_Throw()
        {
            // Arrange
            var product = new Product { Sku = 1, Name = "Nome teste 1", Inventory = new Inventory() };

            // Act, Assert
            Assert.Throws<ObjetoNaoEncontradoNoBDException>(
                () => productDao.Edit(1, product));

            // Assert
            Assert.Equal(0, products.Count);
        }

        #endregion

        #region Delete

        [Fact]
        public void Delete_ProductExists_Success()
        {
            // Arrange
            var product = new Product { Sku = 1, Name = "Nome teste 1", Inventory = new Inventory() };
            products.Add(product);

            // Act
            productDao.Delete(1);

            // Assert
            Assert.Equal(0, products.Count);
        }

        [Fact]
        public void Delete_ProductDontExists_Throw()
        {
            // Act, Assert
            Assert.Throws<ObjetoNaoEncontradoNoBDException>(
                () => productDao.Delete(1));
        }

        #endregion
    }
}
