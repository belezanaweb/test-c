using System.Collections.Generic;
using System.Linq;

namespace Domain.Dtos
{
    public class InventoryListDto
    {
        public int Quantity => Warehouses.Sum(w => w.Quantity);
        
        public List<WarehouseDto> Warehouses { get; set; }
    }
}
