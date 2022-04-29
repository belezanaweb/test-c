using BackEndTest.Domain.Entities;
using BackEndTest.Domain.Interfaces;
using BackEndTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndTest.Infra.Data.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateWarehousesAsync(List<Warehouse> warehouses, int productSku)
        {
            if (warehouses.Count > 0)
            {
                try
                {
                    foreach (var warehouse in warehouses)
                    {
                        warehouse.ProductSku = productSku;
                        _context.Add(warehouse);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<List<Warehouse>> GetWarehousesByProductSkuAsync(int productSku)
        {
            return await _context.Warehouses.Where(i => i.ProductSku == productSku).ToListAsync();
        }

        public async Task<bool> RemoveWarehousesByProductSkuAsync(int productSku)
        {
            var warehouses = _context.Warehouses.Where(i => i.ProductSku == productSku).ToList();
            if (warehouses != null)
            {
                try
                {
                    foreach (var warehouse in warehouses)
                    {
                        _context.Remove(warehouse);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> UpdateWarehousesBySkuAsync(List<Warehouse> warehouses)
        {
            if (warehouses != null || warehouses.Count > 0)
            {
                try
                {
                    foreach (var warehouse in warehouses)
                    {
                        _context.Update(warehouse);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
