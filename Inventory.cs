using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdAPI.Models {
    public class Inventory {

        public int quantity { get; set; }

        public static List<Warehouse> warehouses = new List<Warehouse>();

        public Inventory(int quantity, Warehouse warehouses) {
            this.quantity = quantity;
            Warehouse Warehouse = warehouses;
        }        

        public Inventory() {   
            new Warehouse();
        return;
        }
    }
}