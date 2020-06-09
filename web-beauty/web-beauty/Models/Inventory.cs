using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_beauty.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Warehouses = new List<Warehouse>();
        }

        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
