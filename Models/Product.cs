using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace Inventory.api.Models
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        public int id { get; set; }

        public int sku { get; set; }
        public string name { get; set; }
        public InventoryProduct inventory { get; set; }
        public bool isMarketable { get { return inventory == null ? false : inventory.quantity > 0; } }
    }
}
