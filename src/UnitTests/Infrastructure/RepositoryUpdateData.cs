using AutoFixture;
using Core.Entities;
using System;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class RepositoryUpdateData : RepositoryTextFixture
    {
        [Fact]
        public void UpdateNameExistingData()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var repository = GetRepository<Product>();            
            product = repository.Add(product);

            Predicate<Product> predicate = x => x.Sku.Equals(product.Sku);
            var savedProduct = repository.GetBy(predicate);

            Assert.Equal(product, savedProduct);

            var editedProduct = product.Clone();
            editedProduct.Name = "Name updated";

            repository.Update(product, editedProduct);

            predicate = x => x.Sku.Equals(editedProduct.Sku);
            var updateProduct = repository.GetBy(predicate);

            Assert.Equal(updateProduct, editedProduct);
            Assert.NotSame(updateProduct, savedProduct);
            Assert.NotEqual(updateProduct, savedProduct);
            Assert.NotEqual(updateProduct.Name, savedProduct.Name);
        }
    }
}
