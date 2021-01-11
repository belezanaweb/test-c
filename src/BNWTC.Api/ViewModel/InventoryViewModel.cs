using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BNWTC.Api.ViewModel
{
    public class InventoryViewModel
    {
        [Key]
        public int Sku { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<WarehouseViewModel> Warehouses { get; set; }
    }
}
