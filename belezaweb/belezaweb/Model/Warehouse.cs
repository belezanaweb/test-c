using Newtonsoft.Json;

namespace belezaweb.Model
{
    public class Warehouse
    {
        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}