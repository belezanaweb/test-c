using Boticario.Backend.Modules.Inventory.BusinessLogic;
using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Backend.Modules.Inventory.Implementation.BusinessLogic
{
    public class DefaultQuantityInventoryCalculator : IQuantityInventoryCalculator
    {
        public long Calc(IList<IInventoryEntity> inventoryEntities)
        {
            return inventoryEntities.Select(p => p.Quantity).Sum();
        }
    }
}
