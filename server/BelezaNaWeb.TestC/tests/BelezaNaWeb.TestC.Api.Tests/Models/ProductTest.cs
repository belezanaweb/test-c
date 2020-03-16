using BelezaNaWeb.TestC.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BelezaNaWeb.TestC.Api.Tests.Models
{
    public class ProductTest
    {
        [Fact]
        public void IsMarketable_IsFalse_Success()
        {
            // Arrange
            var product = new Product
            {
                Inventory = new Inventory { }
            };

            // Assert
            Assert.False(product.IsMarketable);
        }
        
        [Fact]
        public void IsMarketable_IsTrue_Success()
        {
            // Arrange
            var product = new Product
            {
                Inventory = new Inventory()
            };
            product.Inventory.Warehouses.Add(new Warehouse { Quantity = 1 });

            // Assert
            Assert.True(product.IsMarketable);
        }

        [Fact]
        public void IsValid_ProductValid_Success()
        {
            // Arrange
            var product = new Product { Sku = 1 };

            // Assert
            Assert.True(product.IsValid());
        }

        [Fact]
        public void IsValid_ProductInvalid_Success()
        {
            // Arrange
            var product = new Product();

            // Assert
            Assert.False(product.IsValid());
        }
    }
}
