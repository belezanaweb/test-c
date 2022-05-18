using Belezanaweb.Domain.Products.Entity;
using Belezanaweb.Domain.Products.Repositories;
using Belezanaweb.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace Belezanaweb.Infra.Data.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(Product entity)
        {
            InMemoryDbContext.Products.Remove(entity);
        }

        public Product Get(long id)
        {
            return InMemoryDbContext.Products.FirstOrDefault(p => p.Sku == id);
        }

        public IEnumerable<Product> GetList(int skip, int take)
        {
            return InMemoryDbContext.Products.Skip(skip).Take(take);
        }

        public void Insert(Product entity)
        {
            InMemoryDbContext.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            var item = InMemoryDbContext.Products.Single(p => p.Sku == entity.Sku);
            var index = InMemoryDbContext.Products.IndexOf(item);
            InMemoryDbContext.Products[index] = entity;
        }
    }
}
