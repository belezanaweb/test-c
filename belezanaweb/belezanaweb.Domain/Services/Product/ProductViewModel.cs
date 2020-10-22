using belezanaweb.Domain.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace belezanaweb.Domain.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryViewModel Inventory { get; set; }

        public bool isMarketable { get; set; }
    }
}
