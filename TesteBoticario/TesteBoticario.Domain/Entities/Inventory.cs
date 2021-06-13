using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBoticario.Domain.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
