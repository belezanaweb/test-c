using System;
using System.Collections.Generic;
using System.Text;

namespace Belezanaweb.Application.Products.DTOs
{
    public class InventoryDTO
    {
        public IEnumerable<WarehouseDTO> Warehouses { get; set; }
    }
}
