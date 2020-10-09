using System.Text.Json.Serialization;

namespace BackendTest.Entities
{
    public class WareHouse
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonIgnore]
        public int InventoryId { get; set; }

        [JsonIgnore]
        public virtual Inventory Inventory { get; set; }

        [JsonPropertyName("type")]    
        public string Type { get; set; }
    }
}
