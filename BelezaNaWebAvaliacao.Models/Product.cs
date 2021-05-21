using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BelezaNaWebAvaliacao.Models
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool isMarketable { get { return Inventory == null ? false : Inventory.Quantity > 0; } }
    }
}
