using System.Collections.Generic;

namespace Belezanaweb.Application.Products.ViewModels
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public IEnumerable<WarehouseViewModel> Warehouses { get; set; }
    }
}
