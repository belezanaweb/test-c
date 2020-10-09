using System;
using System.Text.Json.Serialization;

namespace BackendTest.Entities
{
    public class Product
    {
        public Product()
        {
            Inventory = new Inventory();
        }        
        
        [JsonPropertyName("sku")]
        public int Sku { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public int InventoryId { get; set; }

        [JsonPropertyName("inventory")]
        public virtual Inventory Inventory { get; set ; }

        [JsonIgnore]
        public bool IsMarketable { get; private set; }

        public void SetIsMarketable()
        {
            IsMarketable = Inventory.Quantity > 0;
        }
    }
}
