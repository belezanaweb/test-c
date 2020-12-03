using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Domain.Repository.Interfaces;
using BrunoTragl.BelezaNaWeb.Infra.Data.Interfaces;
using System;
using System.Linq;

namespace BrunoTragl.BelezaNaWeb.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }
        public Product Get(long sku)
        {
            try
            {
                return _context.Products.FirstOrDefault(p => p.Sku == sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Any(long sku)
        {
            try
            {
                return _context.Products.Any(p => p.Sku == sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(Product product)
        {
            try
            {
                _context.Products.Add(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Product product)
        {
            try
            {
                Product model = _context.Products.FirstOrDefault(p => p.Sku == product.Sku);
                model.Name = product.Name;
                model.Inventory = model.Inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Remove(long sku)
        {
            try
            {
                Product product = _context.Products.FirstOrDefault(p => p.Sku == sku);
                _context.Products.Remove(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
