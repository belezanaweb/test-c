using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ConcurrentDictionary<int, IList<IInventory>> database;

        public InventoryRepository()
        {
            this.database = new ConcurrentDictionary<int, IList<IInventory>>();
        }

        public async Task<IList<IInventory>> GetAll(int sku)
        {
            return await Task.Run(() =>
            {
                if (this.database.TryGetValue(sku, out IList<IInventory> inventories))
                {
                    return inventories;
                }
                else
                {
                    return new List<IInventory>(0);
                }
            });
        }

        public async Task SaveAll(int sku, IList<IInventory> inventories)
        {
            await Task.Run(() =>
            {
                this.database.AddOrUpdate(sku, inventories, (key, value) => inventories );
            });
        }

        public async Task DeleteAll(int sku)
        {
            await Task.Run(() =>
            {
                this.database.TryRemove(sku, out _);
            });
        }
    }
}
