using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Boticario.Backend.Data.Database
{
    public interface IDatabase
    {
        ConcurrentDictionary<int, IProductEntity> Products { get; }
        ConcurrentDictionary<int, IList<IInventoryEntity>> Inventories { get; }
    }
}
