using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.BusinessLogic
{
    public interface IQuantityInventoryCalculator
    {
        long Calc(IList<IInventoryEntity> inventoryEntities);
    }
}
