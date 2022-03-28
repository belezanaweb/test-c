using System.Collections.Generic;

namespace BackendTest.DTOs.ProductUpdate
{
    public class InventoryUpdateDTO
    {
        public int Quantity { get; set; }
        public IEnumerable<WarehouseUpdateDTO> Warehouses { get; set; }
    }
}
