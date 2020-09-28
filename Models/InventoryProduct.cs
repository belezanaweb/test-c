using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace Inventory.api.Models
{
    [JsonObject("inventory")]
    public class InventoryProduct
    {
        [Key]
        [System.Text.Json.Serialization.JsonIgnore]
        public int id { get; set; }

        public int quantity { get { return warehouses == null ? 0 : warehouses.Sum(t => t.quantity); } }

        public IList<Warehouse> warehouses { get; set; }
    }
}
