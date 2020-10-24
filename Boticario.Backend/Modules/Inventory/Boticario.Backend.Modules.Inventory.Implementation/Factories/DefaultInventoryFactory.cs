using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Implementation.Exceptions;
using Boticario.Backend.Modules.Inventory.Implementation.Models;
using Boticario.Backend.Modules.Inventory.Models;
using System;

namespace Boticario.Backend.Modules.Inventory.Implementation.Factories
{
    public class DefaultInventoryFactory : IInventoryFactory
    {
        public IInventory Create(string locality, int quantity, string type)
        {
            if (string.IsNullOrWhiteSpace(locality))
            {
                throw new InventoryValidationException("Locality is missing!");
            }

            if (quantity < 0)
            {
                throw new InventoryValidationException("Quantity is invalid!");
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new InventoryValidationException("Type is missing!");
            }

            return new DefaultInventory()
            {
                Locality = locality.Trim(),
                Quantity = quantity,
                Type = type.Trim()
            };
        }
    }
}
