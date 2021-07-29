using BWEBTestBack.Business.Interfaces;
using BWEBTestBack.Business.Models;
using BWEBTestBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWEBTestBack.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private BWEBTestContext _context;

        public ProductRepository(BWEBTestContext context)
        {
            _context = context;
        }

        public virtual async Task Add(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<Product> GetBySku(int sku)
        {
            var product = await _context.Set<Product>()
                .Include(p => p.Inventory)
                .Include(p => p.Inventory.Warehouses)
                .FirstOrDefaultAsync(p => p.Sku == sku);

            if (product != null)
            {
                var qtd = _context.Warehouses
                    .Where(w => w.InventoryId == product.Inventory.Id)
                    .Select(w => w.Quantity).Sum();

                product.Inventory.Quantity = qtd;
                product.IsMarketable = qtd > 0;
            }

            return product;
        }

        public virtual async Task Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteBySku(int sku)
        {
            _context.RemoveRange(_context.Products.Where(p => p.Sku == sku));
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<Product>> GetAll()
        {
            return await _context.Set<Product>()
                .ToListAsync();
        }
    }
}
