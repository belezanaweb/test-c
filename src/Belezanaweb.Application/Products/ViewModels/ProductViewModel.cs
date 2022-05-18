using Belezanaweb.Domain.Products.Entity;
using System.Collections.Generic;

namespace Belezanaweb.Application.Products.ViewModels
{
    public class ProductViewModel
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public InventoryViewModel Inventory { get; set; }

    }
}
