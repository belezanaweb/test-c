using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Required(ErrorMessage = "The Sku is Required")]
        public int Sku { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Inventory is Required")]
        public InventoryViewModel Inventory { get; set; }
        public bool IsMarketable => Inventory?.Quantity > 0;
    }
}
