using System.ComponentModel.DataAnnotations;

namespace DesafioBelezaNaWeb.Models
{
    public class Product
    {
        [Range(1, long.MaxValue, ErrorMessage = "It is necessary to inform the product SKU.")]
        public long Sku { get; set; }
        
        [Required(ErrorMessage = "It is necessary to inform the product Name.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "It's necessary to inform Inventory.")]
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; } = false;
    }
}
