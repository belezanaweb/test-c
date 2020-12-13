using System.Collections.Generic;

namespace Desafio.Application.ViewModels.Read
{
    public class InventoryReadViewModel
    {
        public int Quantity { get; set; }
        public List<WarehouseReadViewModel> Warehouses { get; set; }
    }

}
