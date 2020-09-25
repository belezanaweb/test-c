using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class WarehouseDto
    {
        #region Public Properties

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        #endregion
    }
}
