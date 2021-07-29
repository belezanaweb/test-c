using BWEBTestBack.Business.Interfaces;
using BWEBTestBack.Business.Models;
using BWEBTestBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BWEBTestBack.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private BWEBTestContext _context;

        public InventoryRepository(BWEBTestContext context)
        {
            _context = context;
        }

        public virtual async Task Add(Inventory inventory)
        {
            _context.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<Inventory> GetByProductId(Guid productId)
        {
            return await _context.Set<Inventory>()
               .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public virtual async Task Update(Inventory inventory)
        {
            _context.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByProductId(Guid productId)
        {
            _context.RemoveRange(_context.Inventories.Where(i => i.ProductId == productId));
            await _context.SaveChangesAsync();
        }
    }
}
