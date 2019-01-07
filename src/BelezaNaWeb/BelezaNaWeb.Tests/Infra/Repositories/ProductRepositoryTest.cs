using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Domain.Products.Enums;
using BelezaNaWeb.Infra.Repositories;
using Xunit;

namespace BelezaNaWeb.Tests.Infra.Repositories
{
    public class ProductRepositoryTest
    {
        private MemoryProductRepository Repository;
        public ProductRepositoryTest()
        {
            Repository = new MemoryProductRepository();
        }

        [Fact(DisplayName = "Should save new product correctly.")]
        public void ShouldSaveNewProductCorrectly()
        {
            var product = new Product(1, "test");
            product.Inventory.Add("SP", ProductInventoryWarehouseType.ECOMMERCE);
            Repository.Save(product);
            var productFromDb = Repository.Get(product.Sku);
            Assert.Equal(product, productFromDb);
        }

        [Fact(DisplayName = "Should update product correctly.")]
        public void ShouldUpdateProductCorrectly()
        {
            var product = new Product(1, "test");
            product.Inventory.Add("SP", ProductInventoryWarehouseType.ECOMMERCE);
            Repository.Save(product);
            var productFromDb = Repository.Get(product.Sku);
            var productInserted = product.Equals(productFromDb);
            product.Inventory.Add("MG", ProductInventoryWarehouseType.PHYSICAL_STORE);
            var updatedProductFromDb = Repository.Get(product.Sku);
            Assert.True(productInserted);
            Assert.Equal(product, updatedProductFromDb);
        }

        [Fact(DisplayName = "Should remove product correctly.")]
        public void ShouldRemoveProductCorrectly()
        {
            var product = new Product(1, "test");
            product.Inventory.Add("SP", ProductInventoryWarehouseType.ECOMMERCE);
            Repository.Save(product);
            var productFromDb = Repository.Get(product.Sku);
            var productInserted = product.Equals(productFromDb);
            Repository.Delete(product.Sku);
            var deletedProduct = Repository.Get(product.Sku);
            Assert.True(productInserted);
            Assert.Null(deletedProduct);
        }
    }
}
