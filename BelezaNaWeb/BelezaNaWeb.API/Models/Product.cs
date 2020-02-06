using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.API.Models
{
    public class Product
    {
        public long Sku { get; set; }

        [Required]
        public string Name { get; set; }

        public Inventory Inventory { get; set; }

        public bool IsMarketable
        {
            get
            {
                return Inventory.Quantity > 0;
            }
        }
    }
}
