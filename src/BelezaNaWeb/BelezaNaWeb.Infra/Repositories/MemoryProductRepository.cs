using System;
using System.Collections.Generic;
using System.Linq;
using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Domain.Products.Interfaces;

namespace BelezaNaWeb.Infra.Repositories
{
    public class MemoryProductRepository : IProductRepository
    {
        private IList<Product> Products;

        public MemoryProductRepository()
        {
            Products = new List<Product>();
        }

        public void Delete(long sku)
        {
            var product = Products.FirstOrDefault(p => p.Sku == sku);

            if (product == null)
                return;

            Products.Remove(product);
        }

        public Product Get(long sku)
        {
            return Products.FirstOrDefault(p => p.Sku == sku);
        }

        public IEnumerable<Product> Get()
        {
            return Products.ToList();
        }

        public void Save(Product product)
        {
            var existingProductIndex = Products.ToList().FindIndex(p => p.Sku == product.Sku);

            if(existingProductIndex >= 0)
            {
                Products[existingProductIndex] = product;
            }
            else
            {
                Products.Add(product);
            }
        }
    }
}
