using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Boticario.Test.Application.Entity
{
    public class Inventory
    {
        public int Id { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
        public int SkuId { get; set; }
        [JsonIgnore]
        public virtual Product Sku { get; set; }
        public virtual IEnumerable<Warehouse> Warehouses { get; set; }
    }
}