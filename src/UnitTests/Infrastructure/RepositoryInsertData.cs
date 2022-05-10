using AutoFixture;
using Core.Entities;
using System;
using System.Linq;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class RepositoryInsertData : RepositoryTextFixture
    {
        [Fact]
        public void InsertNewData()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var repository = GetRepository<Product>();
            product = repository.Add(product);

            Predicate<Product> predicate = x => x.Sku.Equals(product.Sku);
            var savedProduct = repository.GetBy(predicate);

            Assert.Equal(product, savedProduct);
        }

        [Fact]
        public void TryToInsertMultipleData()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>(5);

            var repository = GetRepository<Product>();

            foreach (var product in products)
            {
                repository.Add(product);
            }

            var productsSaved = repository.GetAll();

            Assert.Equal(products, productsSaved);
            Assert.True(products.Count() == productsSaved.Count());
        }

    }
}
