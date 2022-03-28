using System.Collections.Generic;

namespace BackendTest.DTOs.ProductCreate
{
    public class InventoryCreateDto
    {
        public int Quantity { get; set; }
        public IEnumerable<WarehouseCreateDto> Warehouses { get; set; }
    }
}
