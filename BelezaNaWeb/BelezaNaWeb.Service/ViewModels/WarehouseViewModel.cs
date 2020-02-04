using Newtonsoft.Json;

namespace BelezaNaWeb.Service.ViewModels
{
    public class WarehouseViewModel
    {
        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}