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
    public class WarehouseRepository : IWarehouseRepository
    {
        private BWEBTestContext _context;

        public WarehouseRepository(BWEBTestContext context)
        {
            _context = context;
        }

        public virtual async Task Add(Warehouse warehouse)
        {
            _context.Add(warehouse);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteInventoryId(Guid inventoryId)
        {
            _context.RemoveRange(_context.Warehouses.Where(w => w.InventoryId == inventoryId));
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<Warehouse>> GetByInventoryId(Guid inventoryId)
        {
            return await _context.Warehouses
                .Where(w => w.InventoryId == inventoryId).ToListAsync();
        }

        public virtual async Task Update(Warehouse warehouse)
        {
            _context.Update(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
