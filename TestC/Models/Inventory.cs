using System.Linq;
using System.Collections.Generic;

namespace TestC.Models
{
    public class Inventory {

        public Inventory()
        {
            this.warehouses = new List<Warehouse>();
        }

        public int quantity { get { return this.warehouses.Sum(w => w.quantity); } } 
        public List<Warehouse> warehouses { get; set; } 
    }
}