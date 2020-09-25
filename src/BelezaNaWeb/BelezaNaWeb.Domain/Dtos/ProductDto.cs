using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class ProductDto
    {
        #region Public Properties

        [JsonProperty("sku")]
        public long Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inventory")]
        public InventoryDto Inventory { get; set; }

        #endregion
    }
}
