using System;
using System.Collections.Generic;

namespace BelezanaWeb.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
