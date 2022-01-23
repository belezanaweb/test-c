using System.Collections.Generic;

namespace Boticario.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public Inventory(int quantity)
        {
            Quantity = quantity;

            Warehouses = new List<Warehouse>();
        }

        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
