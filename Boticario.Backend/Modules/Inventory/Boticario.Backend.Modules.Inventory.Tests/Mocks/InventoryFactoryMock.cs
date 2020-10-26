using Boticario.Backend.Modules.Inventory.Factories;
using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Backend.Modules.Inventory.Tests.Mocks
{
    internal class InventoryFactoryMock : IInventoryFactory
    {
        public int CreateEntityEvents { get; private set; }

        public InventoryFactoryMock()
        {
            this.CreateEntityEvents = 0;
        }

        public IInventoryEntity CreateEntity(string locality, long quantity, string type)
        {
            this.CreateEntityEvents++;
            return new InventoryEntityMock() { Locality = locality, Quantity = quantity, Type = type };
        }

        public IInventoryDetails CreateDetails(IList<IInventoryEntity> inventories)
        {
            return new InventoryDetailsMock()
            {
                Warehouses = inventories.Select(p => (IInventoryWarehouse)new InventoryWarehouseMock()
                {
                    Locality = p.Locality,
                    Quantity = p.Quantity,
                    Type = p.Type
                }).ToList()
            };
        }
    }
}
