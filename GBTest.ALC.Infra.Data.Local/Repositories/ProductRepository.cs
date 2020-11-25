using System;
using System.Linq;
using System.Collections.Generic;
using GBTest.ALC.Domain.Entities;

namespace GBTest.ALC.Infra.Data.Local.Repositories
{
    public class ProductRepository : Domain.Interfaces.IProductRepository
    {
        //GoF Singleton
        private List<Product> _Products;
        private List<Product> Products
        {
            get
            {
                if (_Products == null)
                    _Products = new List<Product>();
                return _Products;
            }
        }

        public Product Get(string id)
        {
            return Products.FirstOrDefault(_ => _.Sku == id);
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public void Add(Product obj)
        {
            if (Products.Any(_ => _.Sku == obj.Sku))
                throw new Exception($"SKY item {obj.Sku} already exists.");
            Products.Add(obj);
        }

        public void Update(Product obj)
        {
            Remove(obj);
            Products.Add(obj);
        }

        public void Remove(Product obj)
        {
            if (Products.RemoveAll(_ => _.Sku == obj.Sku) == 0)
                throw new Exception($"Item not found. Reference: {obj.Sku}.");
        }

        //Enunciado do git pede para não persistir
        public void Dispose()
        {
            _Products = null;
        }

    }
}
