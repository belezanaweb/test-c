using System.Collections.Generic;

namespace Model.Models
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}