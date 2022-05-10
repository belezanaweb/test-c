using AutoFixture;
using Core.Entities;
using System;
using Xunit;

namespace UnitTests.Core
{
    public class ProductServiceUpdateData : ProductServiceTextFixture
    {

        [Fact]
        public void UpdateProduct()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.Equal(product, savedProduct);

            var editedProduct = product.Clone();
            var editedName = fixture.Create<string>();
            editedProduct.Name = editedName;

            service.UpdateProduct(editedProduct.Sku, editedProduct);

            var updatedProduct = service.GetProduct(editedProduct.Sku);

            Assert.Equal(updatedProduct, editedProduct);
            Assert.Equal(updatedProduct.Name, editedName);

            Assert.NotSame(updatedProduct, savedProduct);
            Assert.NotEqual(updatedProduct, savedProduct);
            Assert.NotEqual(updatedProduct.Name, savedProduct.Name);

        }

        [Fact]
        public void UpdateDifferentSkuFromProduct()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.Equal(product, savedProduct);

            var editedProduct = product.Clone();
            var sku = fixture.Create<int>();
                      

            Assert.Throws<ArgumentException>(() => service.UpdateProduct(sku, editedProduct));
            Assert.NotEqual(sku, product.Sku);

        }


        [Fact]
        public void UpdateNullProduct()
        {
            Product product = null;
            int sku = 0;

            var service = GetProductService();

            Assert.Throws<ArgumentNullException>(() => service.UpdateProduct(sku, product));

        }


        [Fact]
        public void UpdateNonExistingSku()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();

            Assert.Throws<InvalidOperationException>(() => service.UpdateProduct(product.Sku, product));

        }

    }
}
