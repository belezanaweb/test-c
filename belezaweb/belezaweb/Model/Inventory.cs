using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace belezaweb.Model
{
    public class Inventory
    {
        [JsonProperty("quantity")]
        public int Quantity
        {
            get
            {
                return Warehouses == null || Warehouses.Count == 0 ? 0 : Warehouses.Sum(s => s.Quantity);
            }
        }

        [JsonProperty("warehouses")]
        public List<Warehouse> Warehouses { get; set; }
    }
}