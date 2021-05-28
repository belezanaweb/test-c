using System;

namespace Inventory.Core
{
    public class Warehouse
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public long Sku { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Inventory Inventory { get; set; }
    }
}
