using System.Collections.Generic;
using Newtonsoft.Json;

namespace BW.AplicationCore.Entities
{
    public class Inventory
    {
        public Inventory()
        {
            WareHouses = new List<WareHouses>();
        }
        public int Quantity { get { return WareHouses.Count; } }
        [JsonProperty(propertyName: "warehouses")]
        public IList<WareHouses> WareHouses { get; set; }
    }
}
