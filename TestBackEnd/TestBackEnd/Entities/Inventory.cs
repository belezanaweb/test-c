using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BackendTest.Entities
{
    public class Inventory    
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }
        
        [JsonIgnore]
        public virtual Product Product { get; set; }

        [JsonPropertyName("warehouses")]
        public virtual List<WareHouse> WareHouses { get; set; }

        [JsonIgnore]
        public int Quantity { get; private set; }

        public void CalculeteQuantity()
        {
            Quantity = WareHouses.Sum(s => s.Quantity);
        }
    }
}
