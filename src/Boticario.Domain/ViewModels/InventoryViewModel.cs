using System.Collections.Generic;

namespace Boticario.Domain.ViewModels
{
    public class InventoryViewModel
    {
       
        //public double Quantity { get; set; }
        public IList<WarehouseViewModel> Warehouses { get; set; }
    }
}
