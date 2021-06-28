using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Models.Product
{
    public class ProductViewModel
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public InventoryViewModel Inventory { get; set; }
    }     
}
