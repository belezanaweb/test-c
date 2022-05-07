using BelezaNaWeb.Entities;
using BelezaNaWeb.Exceptions;
using BelezaNaWeb.Services;
using System;
using Xunit;
using System.Linq;

namespace BelezaNaWeb.UnitTests
{
    public class ProductTests
    {

        [Fact]
        public void AddProduct_ProductDoesNotExists_DoesNotThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            var exception = Record.Exception(() => StorageControl.AddProduct(product));

            Assert.Null(exception);
        }

        [Fact]
        public void AddProduct_ProductDoesExists_DoesThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            product.sku = 1;

            StorageControl.AddProduct(product);

            DomainException exception = Assert.Throws<DomainException>(() => StorageControl.AddProduct(product));

            Assert.Equal("Produto com este sku já existe na base!", exception.Message);
        }

        [Fact]
        public void AddProduct_ProductHasNegativeQuantity_DoesThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            product.sku = 2;

            product.inventory.warehouses[0].quantity = -1;

            DomainException exception = Assert.Throws<DomainException>(() => StorageControl.AddProduct(product));

            Assert.Equal("Valor da quantidade de um ou mais dos estoques está negativo!", exception.Message);
        }


        [Fact]
        public void GetProduct_ProductDoesExists_DoesNotThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            long sku = 3;

            product.sku = sku;

            StorageControl.AddProduct(product);

            var result = StorageControl.GetProduct(sku);

            Assert.Equal(product, result);
        }

        [Fact]
        public void GetProduct_ProductDoesNotExists_DoesThrowException()
        {

            DomainException exception = Assert.Throws<DomainException>(() => StorageControl.GetProduct(4));

            Assert.Equal("Sku não existe na base!", exception.Message);
        }


        [Fact]
        public void UpdateProduct_ProductDoesNotExists_DoesThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            DomainException exception = Assert.Throws<DomainException>(() => StorageControl.UpdateProduct(5, product));

            Assert.Equal("Sku não existe na base!", exception.Message);
        }

        [Fact]
        public void UpdateProduct_ProductDoesExists_DoesNotThrowException()
        {
            Product product = TestsUtil.GetMockProduct();
            
            product.sku = 6;

            StorageControl.AddProduct(product);

            var exception = Record.Exception(() => StorageControl.UpdateProduct(6, product));

            Assert.Null(exception);
        }

        [Fact]
        public void UpdateProduct_ProductHasNegativeQuantity_DoesThrowException()
        {
            Product product = TestsUtil.GetMockProduct();

            product.sku = 7;

            StorageControl.AddProduct(product);

            product.inventory.warehouses[0].quantity = -1;

            DomainException exception = Assert.Throws<DomainException>(() => StorageControl.UpdateProduct(7, product));

            Assert.Equal("Valor da quantidade de um ou mais dos estoques está negativo!", exception.Message);
        }


        [Fact]
        public void GetProduct_ProductDoesExists_QuantityIsRight()
        {
            Product product = TestsUtil.GetMockProduct();

            long sku = 8;

            product.sku = sku;

            StorageControl.AddProduct(product);

            var result = StorageControl.GetProduct(sku);
            
            int totalQuantity = product.inventory.warehouses.Sum(c => c.quantity);

            Assert.Equal(totalQuantity, result.inventory.quantity);
        }

        [Fact]
        public void GetProduct_ProductDoesExists_IsNotMarketable()
        {
            Product product = TestsUtil.GetMockProduct();

            long sku = 9;

            product.sku = sku;

            product.inventory = new Inventory();

            StorageControl.AddProduct(product);

            var result = StorageControl.GetProduct(sku);

            Assert.False(result.isMarketable);
        }
    }
}
