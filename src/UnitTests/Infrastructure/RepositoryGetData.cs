using AutoFixture;
using Core.Entities;
using System;
using System.Linq;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class RepositoryGetData : RepositoryTextFixture
    {
        [Fact]
        public void GetExistingData()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();

            var repository = GetRepository<Product>();
            product = repository.Add(product);

            Predicate<Product> predicate = x => x.Sku.Equals(product.Sku);
            var savedProduct = repository.GetBy(predicate);

            Assert.Equal(product, savedProduct);
        }


        public void GetAllData()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>(100);

            var repository = GetRepository<Product>();
            foreach (var item in products)
            {
                repository.Add(item);
            }

            var savedProducts = repository.GetAll();

            Assert.Equal(products, savedProducts);
        }

        public void GetManyDataCriteria()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>(100);

            var repository = GetRepository<Product>();
                        
            foreach (var item in products)
            {
                repository.Add(item);
            }

            Func<Product, bool> predicate = x => x.Inventory.Quantity < 3;

            var savedProducts = repository.GetMany(predicate);

            Assert.True(products.Where(predicate).Count() == savedProducts.Count());
        }
    }
}
