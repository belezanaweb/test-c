using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class InventoryDetailsMock : IInventoryDetails
    {
        public long Quantity { get; set; }
        public IList<IInventoryWarehouse> Warehouses { get; set; }
    }

    internal class InventoryWarehouseMock : IInventoryWarehouse
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
