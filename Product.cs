using System.Collections.Generic;

namespace ProdAPI.Models {
    public class Product {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }        

        public Product(int sku, string name, Inventory inventory) {
            this.sku = sku;
            this.name = name;            
            this.inventory = inventory;
            new Inventory();
        }
        private void car() {

        }
    }
}