using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ViewModel
{
    public class ProductViewModel
    {
        public int SKU { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

    }

    public class Inventory
    {
        public List<Warehouse> Warehouses { get; set; }
    }

    public class Warehouse
    {
        public string Locality { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }

    public class ReturnProductViewModel
    {
        public int SKU { get; set; }
        public string Name { get; set; }
        public ReturnInventory Inventory { get; set; }
        public bool isMarketable { get; set; }

    }

    public class ReturnInventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }

}
