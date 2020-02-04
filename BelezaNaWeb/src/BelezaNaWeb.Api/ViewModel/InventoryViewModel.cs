using Newtonsoft.Json;

namespace BelezaNaWeb.Api.ViewModel
{
    public class InventoryViewModel
    {
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [JsonProperty("warehouses")]
        public WarehouseViewModel[] Warehouses { get; set; }
    }
}