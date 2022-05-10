using AutoFixture;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace UnitTests.Core
{
    public class ProductServiceDeleteData : ProductServiceTextFixture
    {

        [Fact]
        public void DeleteExistingProduct()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();
            product = service.InsertProduct(product);

            var ret = service.DeleteProduct(product.Sku);

            Assert.True(ret);
            Assert.Null(service.GetProduct(product.Sku));
        }

        [Fact]
        public void DeleteNonExistingSku()
        {
            var fixture = new Fixture();
            var sku = fixture.Create<int>();

            var service = GetProductService();

            var product = service.GetProduct(sku);

            Assert.Null(product);

            Assert.Throws<ArgumentException>(() => service.DeleteProduct(sku));
            

        }
    }
}
