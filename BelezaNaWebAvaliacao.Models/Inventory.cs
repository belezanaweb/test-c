using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BelezaNaWebAvaliacao.Models
{
    [JsonObject("inventory")]
    public class Inventory
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Key]
        public int Id { get; set; }

        public int Quantity { get { return Warehouses == null ? 0 : Warehouses.Sum(t => t.quantity); } }

        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
