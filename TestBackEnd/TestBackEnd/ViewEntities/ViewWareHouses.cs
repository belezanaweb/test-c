using System.Text.Json.Serialization;

namespace BackendTest.ViewEntities
{
    public class ViewWareHouse
    {
        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
       
        [JsonPropertyName("type")]    
        public string Type { get; set; }
    }
}
