using System;
using System.Collections.Generic;

namespace Inventory.Core
{
    public class Inventory
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public long Sku { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
