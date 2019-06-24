using System;
using System.Text;
using Newtonsoft.Json;

namespace BW.AplicationCore.Entities
{
    public class Product
    {
        public Product()
        {
            Inventory = new Inventory();
        }

        [JsonProperty(propertyName:"sku")]
        public int Sku { get; set; }
        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }
        [JsonProperty(propertyName:"inventory")]
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get { return Inventory.Quantity > 0; } }
    }
}
