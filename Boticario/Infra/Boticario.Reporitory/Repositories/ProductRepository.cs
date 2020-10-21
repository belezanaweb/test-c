using System.Collections.Generic;
using System.Linq;
using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces.Repositories;

namespace Boticario.Reporitory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _db = new List<Product>();

        public Product GetProductBySku(int sku)
        {
            var product = _db.FirstOrDefault(c => c.Sku == sku);
            return product;
        }

        public Product Add(Product model)
        {
            _db.Add(model);
            return model;
        }

        public Product Update(Product model)
        {
            _db.ForEach(i =>
            {
                if (i.Sku == model.Sku)
                {
                    i = model;
                    return;
                }
            });

            return model;
        }

        public bool Delete(int sku)
        {
            var newDb = _db.Where(c => c.Sku != sku).ToList();

            if (_db.Count() == newDb.Count())
                return false;

            _db = newDb;
            return true;
        }
    }
}
