using Newtonsoft.Json;
using System.Collections.Generic;

namespace TesteRestfulWebApi.Models
{ 
    public class ProdutoModel
    {
        [JsonProperty("sku")]
        public int sku { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("inventory")]
        public Inventory inventory { get; set; }

        [JsonProperty("isMarketable")]
        public bool isMarketable { get; set; }

    }
    public class Warehouse
    {
        [JsonProperty("locality")]
        public string locality { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Inventory
    {
        [JsonProperty("quantity")]
        public int quantity { get; set; }

        [JsonProperty("warehouses")]
        public IList<Warehouse> warehouses { get; set; }
    }
}