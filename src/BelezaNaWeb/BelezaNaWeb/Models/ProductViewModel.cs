using System;
namespace BelezaNaWeb.Models
{
    public class ProductViewModel
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryViewModel Inventory { get; set; }
    }
}
