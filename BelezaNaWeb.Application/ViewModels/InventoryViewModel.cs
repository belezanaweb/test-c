using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BelezaNaWeb.Application.ViewModels
{
    public class InventoryViewModel
    {
        public InventoryViewModel()
        {
            Warehouses = new List<WarehouseViewModel>();
        }
        
        [Required(ErrorMessage = "Warehouses list is Required")]
        public List<WarehouseViewModel> Warehouses { get; set; }
        public int Quantity => Warehouses?.Sum(w => w.Quantity) ?? 0;

    }
}
