using Newtonsoft.Json;

namespace BelezaNaWeb.Service.ViewModels
{
    public class InventoryViewModel
    {
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [JsonProperty("warehouses")]
        public WarehouseViewModel[] Warehouses { get; set; }
    }
}