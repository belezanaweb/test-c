using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class InventoryDto
    {
        #region Public Properties

        [JsonProperty("quantity")]
        public int Quantity => Warehouses.Sum(x => x.Quantity);

        [JsonProperty("quantity")]
        public bool IsMarketable => Quantity > 0;

        [JsonProperty("warehouses")]
        public IEnumerable<WarehouseDto> Warehouses { get; set; } = new List<WarehouseDto>();

        #endregion
    }
}
