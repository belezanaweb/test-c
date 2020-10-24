using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Models;
using System;

namespace Boticario.Backend.Modules.Inventory.Implementation.Factories
{
    public class DefaultInventoryFactory : IInventoryFactory
    {
        public IInventory Create(string locality, int quantity, string type)
        {
            throw new NotImplementedException();
        }
    }
}
