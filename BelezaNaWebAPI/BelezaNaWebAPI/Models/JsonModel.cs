using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelezaNaWebAPI.Models
{
    public class Warehouse
    {
        public string locality { get; set; }
        public string quantity { get; set; }
        public string type { get; set; }
    }

    public class Inventory
    {
        public string quantity { get; set; }
        public List<Warehouse> warehouses { get; set; }
    }

    public class JsonModel
    {
        public string sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public string isMarketable { get; set; }
    }
}