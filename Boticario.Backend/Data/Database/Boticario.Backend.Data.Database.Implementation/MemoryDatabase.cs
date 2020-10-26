using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Boticario.Backend.Data.Database.Implementation
{
    public class MemoryDatabase : IDatabase
    {
        public ConcurrentDictionary<int, IProductEntity> Products { get; private set; }
        public ConcurrentDictionary<int, IList<IInventoryEntity>> Inventories { get; private set; }

        public MemoryDatabase()
        {
            this.Products = new ConcurrentDictionary<int, IProductEntity>();
            this.Inventories = new ConcurrentDictionary<int, IList<IInventoryEntity>>();
        }
    }
}
