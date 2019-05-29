using Newtonsoft.Json;

namespace belezaweb.Model
{
    public class Product
    {
        [JsonProperty("sku")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inventory")]
        public Inventory Inventory { get; set; }

        [JsonProperty("isMarketable")]
        public bool IsMarketable
        {
            get
            {
                if (Inventory == null || Inventory.Quantity == 0)
                    return false;
                else if (Inventory.Quantity > 0)
                    return true;

                return false;
            }
        }
    }
}