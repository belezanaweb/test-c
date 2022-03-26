using System.Text.Json.Serialization;

namespace ProductApi.Models
{
    public class ProductWarehouse
    {
        public string? Locality { get; set; }
        public int Quantity { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WarehouseTypes Type { get; set; }
    }
}