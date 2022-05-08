using BelezaNaWeb.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BelezaNaWeb.Entities
{
    public class Warehouse
    {
        [Required]
        public string locality { get; set; }
        
        public int quantity { get; set; }
        
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WarehousesTypeEnum type { get; set; }
    }
}
