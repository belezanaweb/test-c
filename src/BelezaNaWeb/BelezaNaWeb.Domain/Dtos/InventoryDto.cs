using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class InventoryDto
    {
        #region Public Properties
        
        [JsonProperty("quantity", Order = 0)]
        public int Quantity => Warehouses.Sum(x => x.Quantity);

        [JsonProperty("isMarketable", Order = 2)]
        public bool IsMarketable => Quantity > 0;

        [JsonProperty("warehouses", Order = 1)]
        public IEnumerable<WarehouseDto> Warehouses { get; set; } = new List<WarehouseDto>();

        #endregion
    }
}
