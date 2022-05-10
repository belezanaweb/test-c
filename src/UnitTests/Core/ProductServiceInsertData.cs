using AutoFixture;
using Core.Entities;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.Core
{
    public class ProductServiceInsertData : ProductServiceTextFixture
    {

        [Fact]
        public void InsertProduct()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var service = GetProductService();
            product = service.InsertProduct(product);

            var savedProduct = service.GetProduct(product.Sku);

            Assert.Equal(product, savedProduct);

        }

        [Fact]
        public void InsertMultipleProduct()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>();

            var service = GetProductService();
            foreach (var product in products)
            {
                service.InsertProduct(product);
            }

            var savedProducs = new List<Product>();
            foreach (var product in products)
            {
                savedProducs.Add(service.GetProduct(product.Sku));
            }                        

            Assert.Equal(products, savedProducs);
            Assert.True(products.Count() == savedProducs.Count());

        }
    }
}
