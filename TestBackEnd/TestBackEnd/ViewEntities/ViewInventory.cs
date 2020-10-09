using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackendTest.ViewEntities
{
    public class ViewInventory    
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("warehouses")]
        public List<ViewWareHouse> WareHouses { get; set; }            
    }
}
