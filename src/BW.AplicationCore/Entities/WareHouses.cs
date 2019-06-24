using Newtonsoft.Json;

namespace BW.AplicationCore.Entities
{
    public class WareHouses
    {
        [JsonProperty(propertyName: "locality")]
        public string Locality { get; set; }
        [JsonProperty(propertyName: "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

    }
}
