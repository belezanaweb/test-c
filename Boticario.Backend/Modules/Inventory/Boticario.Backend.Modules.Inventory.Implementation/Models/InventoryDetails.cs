using Boticario.Backend.Modules.Inventory.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.Implementation.Models
{
    internal class InventoryDetails : IInventoryDetails
    {
        public long Quantity { get; set; }
        public IList<IInventoryWarehouse> Warehouses { get; set; }
    }

    internal class InventoryWarehouse : IInventoryWarehouse
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
