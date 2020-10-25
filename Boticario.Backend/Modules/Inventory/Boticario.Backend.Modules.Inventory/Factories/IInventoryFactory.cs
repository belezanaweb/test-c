using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Inventory.Factories
{
    public interface IInventoryFactory
    {
        IInventoryEntity Create(string locality, long quantity, string type);
    }
}
