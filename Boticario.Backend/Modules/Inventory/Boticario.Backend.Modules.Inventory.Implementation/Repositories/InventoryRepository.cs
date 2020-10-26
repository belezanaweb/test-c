using Boticario.Backend.Data.DatabaseContext;
using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Implementation.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IDatabaseContext databaseContext;

        public InventoryRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IList<IInventoryEntity>> GetAll(int sku)
        {
            return await this.databaseContext.ExecuteReader(async (connection) =>
            {
                return await Task.Run(() =>
                {
                    if (connection.Database.Inventories.TryGetValue(sku, out IList<IInventoryEntity> inventories))
                    {
                        return inventories;
                    }
                    else
                    {
                        return new List<IInventoryEntity>(0);
                    }
                });
            });
        }

        public async Task SaveAll(int sku, IList<IInventoryEntity> inventories)
        {
            await this.databaseContext.ExecuteWriter(async (connection) =>
            {
                await Task.Run(() =>
                {
                    connection.Database.Inventories.AddOrUpdate(sku, inventories, (key, value) => inventories);
                });
            });
        }

        public async Task DeleteAll(int sku)
        {
            await this.databaseContext.ExecuteWriter(async (connection) =>
            {
                await Task.Run(() =>
                {
                    connection.Database.Inventories.TryRemove(sku, out _);
                });
            });
        }
    }
}
