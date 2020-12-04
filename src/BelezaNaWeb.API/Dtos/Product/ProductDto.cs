using BelezaNaWeb.API.Dtos.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Dtos.Product
{
    public class ProductDto
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryDto Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                return Inventory.Quantity > 0;
            }
        }
    }
}
