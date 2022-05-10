using AutoFixture;
using Core.Entities;
using System;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class RepositoryDeleteData : RepositoryTextFixture
    {
        [Fact]
        public void DeleteExistingData()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var repository = GetRepository<Product>();
            product = repository.Add(product);

            Predicate<Product> predicate = x => x.Sku.Equals(product.Sku);
            var savedProduct = repository.GetBy(predicate);

            repository.Delete(savedProduct);

            Assert.Null(repository.GetBy(x => x.Sku.Equals(savedProduct.Sku)));
        }

        [Fact]
        public void DeleteNonExistingData()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var repository = GetRepository<Product>();

            Assert.Throws<InvalidOperationException>(() => repository.Delete(product));
        }
    }
}
