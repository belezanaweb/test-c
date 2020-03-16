using BelezaNaWeb.Shared.Entities;

namespace BelezaNaWeb.Domain.Entities
{
    public class Product : Entity {
        public Product(int sku, string name, Inventory inventory)
        {
            this.sku = sku;
            this.name = name;
            this.inventory = inventory;
        }
        private Product() { }
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { 
            get {
                //Um produto é marketable sempre que seu inventory.quantity for maior que 0
                return this.inventory.quantity > 0;
            }
        }
    }
}
