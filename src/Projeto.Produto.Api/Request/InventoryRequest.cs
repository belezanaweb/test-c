using System.Collections.Generic;

namespace Projeto.Produtos.Api.Request
{
    public class InventoryRequest
    {
        public IEnumerable<WarehouseRequest> Warehouses { get; set; }
    }
}
