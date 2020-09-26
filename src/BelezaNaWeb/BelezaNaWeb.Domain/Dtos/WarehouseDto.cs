using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class WarehouseDto
    {
        #region Public Properties

        [JsonProperty("locality", Order = 0)]
        public string Locality { get; set; }

        [JsonProperty("quantity", Order = 1)]
        public int Quantity { get; set; }

        [JsonProperty("type", Order = 2)]
        public string Type { get; set; }

        #endregion
    }
}
