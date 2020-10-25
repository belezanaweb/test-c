using System.Collections.Generic;

namespace Boticario.Backend.Modules.Inventory.Dto
{
    public class InventoryOperationDto
    {
        public IList<InventoryWarehouseOperationDto> Warehouses { get; set; }
    }

    public class InventoryWarehouseOperationDto
    {
        public string Locality { get; set;  }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
