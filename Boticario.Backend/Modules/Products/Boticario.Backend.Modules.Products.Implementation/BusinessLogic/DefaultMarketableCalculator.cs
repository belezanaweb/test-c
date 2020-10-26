using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.BusinessLogic;

namespace Boticario.Backend.Modules.Products.Implementation.BusinessLogic
{
    public class DefaultMarketableCalculator : IMarketableCalculator
    {
        public bool Calc(IInventoryDetails inventoryDetails)
        {
            return inventoryDetails.Quantity > 0;
        }
    }
}
