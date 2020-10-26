using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.Factories
{
    public interface IInventoryFactory
    {
        IInventoryEntity CreateEntity(string locality, long quantity, string type);
        IInventoryDetails CreateDetails(IList<IInventoryEntity> inventories);
    }
}
