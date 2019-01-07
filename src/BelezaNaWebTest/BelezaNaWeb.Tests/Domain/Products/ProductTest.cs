using System;
using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Domain.Products.Enums;
using BelezaNaWeb.Domain.Products.Exceptions;
using Xunit;

namespace BelezaNaWeb.Tests.Domain.Products
{
    public class ProductTest
    {
        [Fact(DisplayName = "Should not create product with negative SKU.")]
        public void ShouldNotCreateproductWithNegativeSku()
        {
            Assert.Throws<InvalidProductSkuException>(() =>
            {
                new Product(-1, "product test");
            });
        }

        [Fact(DisplayName = "Should not create product with empty name.")]
        public void ShouldNotCreateProductWithEmptyName()
        {
            Assert.Throws<InvalidProductNameException>(() => {
                new Product(1, "");
            });
        }

        [Fact(DisplayName = "Should not add product with empty warehouse locality name.")]
        public void ShouldNotAddProductWithEmptyWarehouseLocalityName()
        {
            var product = new Product(1, "test");
            Assert.Throws<InvalidProductWarehouseNameException>(() =>
            {
                product.Add("", ProductInventoryWarehouseType.ECOMMERCE);
            });
        }

        [Fact(DisplayName = "Should not add/update product with negative quantity.")]
        public void ShouldNotAddProductWithInvalidQuantity()
        {
            var product = new Product(1, "test");
            Assert.Throws<InvalidProductWarehouseNameException>(() =>
            {
                product.AddOrUpdate("SP", ProductInventoryWarehouseType.ECOMMERCE, -1);
            });
        }

        [Fact(DisplayName = "Should create empty product with correct inventory quantity.")]
        public void ShouldCreateProductWithCorrectInventoryQuantity()
        {
            var product = new Product(1, "test");
            Assert.Equal(0, product.Inventory.Quantity);
        }

        [Fact(DisplayName = "Should create empty product with correct marketable indicator.")]
        public void ShouldCreateProductWithCorrectMarketableIndicator()
        {
            var product = new Product(1, "test");
            Assert.False(product.IsMarketable);
        }

        [Fact(DisplayName = "Should add product correctly.")]
        public void ShouldAddProductCorrectly()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";

            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);

            var warehouse = product.Inventory.GetByWarehouseName(warehouseName);
            Assert.True(warehouse != null);
            Assert.Equal("1", warehouse.Quantity.ToString());
        }

        [Fact(DisplayName = "Should get warehouse by name correctly.")]
        public void ShouldGetWarehouseByNameCorrectly()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";

            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);

            var warehouse = product.Inventory.GetByWarehouseName(warehouseName);
            Assert.True(warehouse != null);
        }

        [Fact(DisplayName = "Should add product when wharehouse does not exist.")]
        public void ShouldAddProductWhenWharehouseDoesNotExist()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";
            var quantity = 2;

            product.AddOrUpdate(warehouseName, ProductInventoryWarehouseType.ECOMMERCE, quantity);

            var warehouse = product.Inventory.GetByWarehouseName(warehouseName);
            Assert.True(warehouse != null);
            Assert.Equal(warehouse.Quantity.ToString(), quantity.ToString());
        }

        [Fact(DisplayName = "Should update product when wharehouse exists.")]
        public void ShouldUpdateProductWhenWharehouseExists()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";
            var quantity = 5;

            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);
            product.AddOrUpdate(warehouseName, ProductInventoryWarehouseType.ECOMMERCE, quantity);

            var warehouse = product.Inventory.GetByWarehouseName(warehouseName);
            Assert.True(warehouse != null);
            Assert.Equal(warehouse.Quantity.ToString(), quantity.ToString());
        }

        [Fact(DisplayName = "Should update inventory quantity correctly when product is added.")]
        public void ShouldUpdateInventoryQuantityCorrectlyWhenProductIsAdded()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";

            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);
            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);

            Assert.Equal(2, product.Inventory.Quantity);
        }

        [Fact(DisplayName = "Should update inventory quantity correctly when product is updated.")]
        public void ShouldUpdateInventoryQuantityCorrectlyWhenProductIsUpdated()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";
            var quantity = 5;

            product.AddOrUpdate(warehouseName, ProductInventoryWarehouseType.ECOMMERCE, quantity);

            Assert.Equal(product.Inventory.Quantity, quantity);
        }

        [Fact(DisplayName = "Should remove product correctly.")]
        public void ShouldRemoveProductCorrectly()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";

            product.Add(warehouseName, ProductInventoryWarehouseType.ECOMMERCE);
            var productWasAdded = product.Inventory.Quantity == 1;

            product.Remove(warehouseName);
            var productWasRemoved = product.Inventory.Quantity == 0;

            Assert.True(productWasAdded);
            Assert.True(productWasRemoved);

        }

        [Fact(DisplayName = "Should throw exception when product wharehouse is not found for deletion.")]
        public void ShouldThrowExceptionWhenProductWharehouseIsNotFoundForDeletion()
        {
            var product = new Product(1, "test");
            Assert.Throws<ProductWarehouseNotFoundForDeletionException>(() => {
                product.Remove("SP");
            });
        }

        [Fact(DisplayName = "Should updte inventory quantity when product is removed.")]
        public void ShouldUpdateInventoryQuantityWhenProductIsRemoved()
        {
            var product = new Product(1, "test");
            var warehouseName = "SP";
            var quantity = 5;

            product.AddOrUpdate(warehouseName, ProductInventoryWarehouseType.ECOMMERCE, quantity);
            var productWasAdded = product.Inventory.Quantity == quantity;

            product.Remove(warehouseName);
            var productWasRemoved = product.Inventory.Quantity == 0;

            Assert.True(productWasAdded);
            Assert.True(productWasRemoved);
        }
    }
}
