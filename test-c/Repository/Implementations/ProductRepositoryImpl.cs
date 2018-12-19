using System;
using System.Collections.Generic;
using System.Linq;
using testc.Model;
using testc.Model.Context;

namespace testc.Repository.Implementations
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private MySQLContext _context;
        public ProductRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public ProductRepositoryImpl()
        {
        }

        public Product Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public void Delete(long sku)
        {
            var result = _context.Products.SingleOrDefault(p => p.Sku.Equals(sku));

            try
            {
                if (result != null) _context.Products.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }


        public Product GetBySku(long sku)
        {
            return _context.Products.SingleOrDefault(p => p.Sku.Equals(sku));
        }

        public Product Update(Product product)
        {
            if (!Exist(product.Sku)) return null;
            var result = _context.Products.SingleOrDefault(p => p.Sku.Equals(product.Sku));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(product);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;

        }

        public bool Exist(long? sku)
        {
            return _context.Products.Any(p => p.Sku.Equals(sku));
        }
    }
}
