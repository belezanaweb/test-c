using Inventory.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.api.Response
{
    public class ProductResponse
    {
        public int sku { get; set; }
        public string name { get; set; }
        public InventoryProduct inventory { get; set; }
        
    }
}
