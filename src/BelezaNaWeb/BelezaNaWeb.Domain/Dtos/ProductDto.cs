using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Dtos
{
    public class ProductDto
    {
        #region Public Properties

        [JsonProperty("sku", Order = 0)]
        public int Sku { get; set; }

        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        [JsonProperty("inventory", Order = 2)]
        public InventoryDto Inventory { get; set; }

        #endregion
    }
}
