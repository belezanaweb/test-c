using System;
using BelezaNaWeb.Core.Model;
using BelezaNaWeb.Core.Repositories;
using System.Collections.Generic;

namespace BelezaNaWeb.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<int, Product> _db = new Dictionary<int, Product>();

        public Product Add(Product product)
        {
            if (_db.ContainsKey(product.Sku))
            {
                throw new ApplicationException("Duplicate sku");
            }

            _db[product.Sku] = product;

            return product;

        }

        public Product Update(Product product)
        {
            if (!_db.ContainsKey(product.Sku))
            {
                _db[product.Sku] = product;
                
            }

            return product;
        }

        public Product GetProductBySku(int sku)
        {
            return !_db.ContainsKey(sku) ? null : _db[sku];
        }

        public bool Delete(int sku)
        {
            if (_db.ContainsKey(sku))
            {
                _db.Remove(sku);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}

