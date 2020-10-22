using belezanaweb.Domain.Entities;
using System.Collections.Generic;

namespace belezanaweb.Domain.ViewModels.Inventory
{
    public class InventoryViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
