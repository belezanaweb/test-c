using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace Inventory.api.Models
{
    [JsonObject("warehouses")]
    public class Warehouse
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Key]
        public int id { get; set; }
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}
