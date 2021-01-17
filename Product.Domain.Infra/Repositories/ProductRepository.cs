using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Infra.Contexts;
using Product.Domain.Repositories;

namespace Product.Domain.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void Create(Entities.Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public Entities.Product GetBySku(int sku)
        {
            return _context.Product.Where(p => p.Sku == sku).
                Include(i => i.Inventory).
                ThenInclude(w => w.Warehouses).FirstOrDefault();            
        }

        public void Update(Entities.Product product)
        {
            _context.Entry(product).State = EntityState.Modified;           
            _context.SaveChanges();
           
        }

        public void Delete(Entities.Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();

        }
    }
}
