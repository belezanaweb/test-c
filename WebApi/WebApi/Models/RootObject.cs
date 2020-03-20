using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Warehouse
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }

    public class Inventory
    {
        internal int quantity { get; set; }
        public List<Warehouse> warehouses { get; set; }
    }

    public class RootObject
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        internal bool isMarketable { get; set; }
    }
}