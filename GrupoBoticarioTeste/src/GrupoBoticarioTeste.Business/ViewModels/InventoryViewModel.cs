using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.ViewModels
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public IEnumerable<WarehouseViewModel> Warehouses { get; set; }
    }
}
