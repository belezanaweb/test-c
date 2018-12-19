using System;
using System.Collections.Generic;

namespace testc.Model
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }

    }
}
