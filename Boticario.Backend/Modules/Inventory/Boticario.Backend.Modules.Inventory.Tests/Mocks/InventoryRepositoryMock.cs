using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Inventory.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Backend.Modules.Inventory.Tests.Mocks
{
    internal class InventoryRepositoryMock : IInventoryRepository
    {
        public IList<IInventoryEntity> Database { get; set; }
        public bool SaveAllWasCalled { get; private set; }
        public bool DeleteAllWasCalled { get; private set; }

        public InventoryRepositoryMock()
        {
            this.Database = new List<IInventoryEntity>();
            this.SaveAllWasCalled = false;
            this.DeleteAllWasCalled = false;
        }

        public async Task<IList<IInventoryEntity>> GetAll(int sku)
        {
            return await Task.Run(() =>
            {
                return this.Database;
            });
        }

        public async Task SaveAll(int sku, IList<IInventoryEntity> inventories)
        {
            await Task.Run(() =>
            {
                this.Database = inventories;
                this.SaveAllWasCalled = true;
            });
        }

        public async Task DeleteAll(int sku)
        {
            await Task.Run(() =>
            {
                this.Database.Clear();
                this.DeleteAllWasCalled = true;
            });
        }
    }
}
