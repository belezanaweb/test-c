using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Models
{
    public class InventoryModel
    {
        [Required(ErrorMessage = "The field warehouses is required")]
        public ICollection<WarehouseModel> Warehouses { get; set; }
        public uint Quantity { get; set; }
        public void SetQuantity(uint quantity)
        {
            Quantity = quantity;
        }
    }
}
