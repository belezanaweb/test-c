using System;
using System.Text.Json.Serialization;

namespace BackendTest.ViewEntities
{
    public class ViewProduct
    {
        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("inventory")]
        public  ViewInventory Inventory { get; set; }

        [JsonPropertyName("isMarketable")]
        public bool IsMarketable { get; set; }        
    }
}
