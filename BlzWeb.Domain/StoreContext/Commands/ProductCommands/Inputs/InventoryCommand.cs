using System.Collections.Generic;

namespace BlzWeb.Domain.StoreContext.Commands.ProductCommands.Inputs
{
    public class InvertoryCommand
    {
        public decimal Quantity { get; set; }
        public List<WarehouseCommand> Warehouses { get; set; }
    }
}
