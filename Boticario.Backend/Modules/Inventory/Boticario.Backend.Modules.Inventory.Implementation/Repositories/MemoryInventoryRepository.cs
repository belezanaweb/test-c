using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Implementation.Repositories
{
    public class MemoryInventoryRepository : IInventoryRepository
    {
        private readonly ConcurrentDictionary<int, IList<IInventoryEntity>> database;

        public MemoryInventoryRepository()
        {
            this.database = new ConcurrentDictionary<int, IList<IInventoryEntity>>();
        }

        public async Task<IList<IInventoryEntity>> GetAll(int sku)
        {
            return await Task.Run(() =>
            {
                if (this.database.TryGetValue(sku, out IList<IInventoryEntity> inventories))
                {
                    return inventories;
                }
                else
                {
                    return new List<IInventoryEntity>(0);
                }
            });
        }

        public async Task SaveAll(int sku, IList<IInventoryEntity> inventories)
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
