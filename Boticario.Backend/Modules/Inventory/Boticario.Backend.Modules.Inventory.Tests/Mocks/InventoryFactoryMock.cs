using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Inventory.Tests.Mocks
{
    internal class InventoryFactoryMock : IInventoryFactory
    {
        public int CreateMethodEvents { get; private set; }

        public InventoryFactoryMock()
        {
            this.CreateMethodEvents = 0;
        }

        public IInventoryEntity Create(string locality, long quantity, string type)
        {
            this.CreateMethodEvents++;
            return new InventoryEntityMock() { Locality = locality, Quantity = quantity, Type = type };
        }
    }
}
