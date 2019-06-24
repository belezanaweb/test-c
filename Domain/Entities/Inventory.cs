using System.Collections.Generic;

namespace Domain.Entities
{
    public class Inventory
    {
        public int quantity { get; set; }
        public IList<Warehouse> warehouses { get; set; }
    }

}
