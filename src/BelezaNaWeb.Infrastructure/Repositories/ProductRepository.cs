using BelezaNaWeb.Domain.Model;
using BelezaNaWeb.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly static Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public int Add(Product entity)
        {
            _products.Add(entity.Sku, entity);
            return entity.Sku;
        }

        public bool Delete(int sku)
        {
            _products.Remove(sku);
            return true;
        }

        public bool Exist(int sku)
        {
            return _products.ContainsKey(sku);
        }

        public Product? Get(int sku)
        {
            return _products.GetValueOrDefault(sku);
        }

        public int Update(Product entity)
        {
            _products[entity.Sku] = entity;
            return entity.Sku;
        }

        public List<Product> List()
        {
            return _products.Values.ToList();
        }
    }
}
