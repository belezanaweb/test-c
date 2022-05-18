using System.Collections.Generic;

namespace Belezanaweb.Domain.Products.Entity
{
    public class Inventory
    {
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}