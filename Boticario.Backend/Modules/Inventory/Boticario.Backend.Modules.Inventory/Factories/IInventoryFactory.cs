using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Inventory.Factories
{
    public interface IInventoryFactory
    {
        IInventory Create(string locality, int quantity, string type);
    }
}
