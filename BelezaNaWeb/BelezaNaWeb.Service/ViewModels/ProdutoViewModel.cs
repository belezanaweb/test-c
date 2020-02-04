using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Service.ViewModels
{
    public class ProdutoViewModel
    {
        [JsonProperty("sku")]
        public long Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inventory")]
        public InventoryViewModel Inventory { get; set; }

        [JsonProperty("isMarketable")]
        public bool? IsMarketable { get; set; }
    }
}
