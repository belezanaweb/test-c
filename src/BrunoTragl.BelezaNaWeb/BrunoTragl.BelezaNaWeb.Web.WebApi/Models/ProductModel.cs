using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "The field sku is required")]
        public long Sku { get; set; }

        [Required(ErrorMessage = "The field name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field inventory is required")]
        public InventoryModel Inventory { get; set; }

        public bool IsMarketable { get; set; }

        public void SetIsMarketable(bool isMarketable)
        {
            IsMarketable = isMarketable;
        }
    }
}
