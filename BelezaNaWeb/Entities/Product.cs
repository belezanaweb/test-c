using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Entities
{
    public class Product
    {
        [Required]
        public long sku { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public Inventory inventory { get; set; }

        public bool isMarketable { get { return this.inventory.quantity > 0; } }
    }
}
