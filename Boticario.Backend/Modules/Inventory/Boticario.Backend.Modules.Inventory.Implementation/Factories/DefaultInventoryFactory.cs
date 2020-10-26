using Boticario.Backend.Modules.Inventory.BusinessLogic;
using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Implementation.BusinessLogic;
using Boticario.Backend.Modules.Inventory.Implementation.Exceptions;
using Boticario.Backend.Modules.Inventory.Implementation.Models;
using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Backend.Modules.Inventory.Implementation.Factories
{
    public class DefaultInventoryFactory : IInventoryFactory
    {
        private readonly IQuantityInventoryCalculator quantityInventoryCalculator; 

        public DefaultInventoryFactory()
        {
            this.quantityInventoryCalculator = new DefaultQuantityInventoryCalculator();
        }

        public IInventoryEntity CreateEntity(string locality, long quantity, string type)
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

            return new InventoryEntity()
            {
                Locality = locality.Trim(),
                Quantity = quantity,
                Type = type.Trim()
            };
        }

        public IInventoryDetails CreateDetails(IList<IInventoryEntity> inventories)
        {
            return new InventoryDetails()
            {
                Quantity = this.quantityInventoryCalculator.Calc(inventories),
                Warehouses = inventories.Select(p => (IInventoryWarehouse)new InventoryWarehouse()
                {
                    Locality = p.Locality,
                    Quantity = p.Quantity,
                    Type = p.Type
                }).ToList()
            };
        }
    }
}
