using Belezanaweb.Domain.Products.Entity;
using System.Collections.Generic;

namespace Belezanaweb.Infra.Data.DbContexts
{
    public static class InMemoryDbContext
    {
        private static IList<Product> _products = new List<Product>();

        public static IList<Product> Products
        {
            get => _products;
        }
    }
}
