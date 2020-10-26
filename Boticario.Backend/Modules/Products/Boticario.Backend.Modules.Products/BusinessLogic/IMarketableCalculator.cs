using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Products.BusinessLogic
{
    public interface IMarketableCalculator
    {
        bool Calc(IInventoryDetails inventoryDetails);
    }
}
