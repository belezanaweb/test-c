using System.Collections.Generic;

namespace TesteBoticario.Domain.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
