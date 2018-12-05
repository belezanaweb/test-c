using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdAPI.Controllers;


namespace ProdAPI.Models {

    public class Warehouse {
        public string locality { get; set; }
        public string type { get; set; }
        public int quantity { get; set; }        

        public Warehouse(string locality, int quantity, string type) {
            this.locality = locality;
            this.quantity = quantity;
            this.type = type;            
        }
        public Warehouse() {            
            Warehouse w1 = new Warehouse("SP", 12, "ECOMMERCE");
            Inventory.warehouses.Add(w1);
            Warehouse w2 = new Warehouse("MOEMA", 3, "PHYSICAL_STORE");
            Inventory.warehouses.Add(w2);
            return;
        }
    }
}