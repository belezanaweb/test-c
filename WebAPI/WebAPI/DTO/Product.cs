using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mvc_WebAPI_Demo.Models
{
    public class Product
    {
        public int sku;
        public string name;
        public Stock inventory;
        [JsonProperty("isMarketable")]
        public bool IsMarketable
        {
            get
            {   
                if (inventory == null || inventory.Quantity == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Product()
        {
            inventory = new Stock();
        }
    }
}