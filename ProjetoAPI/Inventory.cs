using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Inventory
    {
        public int quantity { get; set; }
        public List<Warehouse> warehouses { get; set; }
    }
}