using System.Collections.Generic;

namespace ApiProduct.Models
{
    public class Inventory
    {
        public int Sku { get; set; }
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}