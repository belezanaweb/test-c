using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Entities
{
    public class Product
    {
        public Product() {
            inventory = new Inventory();
        }

        public long sku { get; set; }

        [Required]
        public string name { get; set; }

        public Inventory inventory { get; set; }

        public bool isMarketable { get { return this.inventory.quantity > 0; } }
    }
}
