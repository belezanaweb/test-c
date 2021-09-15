using System.Collections.Generic;

namespace Projeto.Produtos.Api.ViewModel
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }

        public IEnumerable<WarehouseViewModel> Warehouses { get; set; }
    }
}
