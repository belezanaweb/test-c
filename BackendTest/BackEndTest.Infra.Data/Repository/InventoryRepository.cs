using BackEndTest.Domain.Entities;
using BackEndTest.Domain.Interfaces;
using BackEndTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndTest.Infra.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateInventoryAsync(Inventory inventory, int productSku)
        {
            if (inventory != null)
            {
                try
                {
                    inventory.ProductSku = productSku;
                    _context.Add(inventory);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<Inventory> GetInventoryByProductSkuAsync(int productSku)
        {
            return await _context.Inventories.Where(i => i.ProductSku == productSku).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveInventoryByProductSkuAsync(int productSku)
        {
            var inventory = _context.Inventories.Where(i => i.ProductSku == productSku).FirstOrDefault();
            if (inventory != null)
            {
                try
                {
                    _context.Remove(inventory);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> UpdateInventoryByProductSkuAsync(Inventory inventory)
        {
            if (inventory != null)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();

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
