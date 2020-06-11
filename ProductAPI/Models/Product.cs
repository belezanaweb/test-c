using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public sealed class Product
    {
        public Product()
        {
            Inventory = new Inventory();
        }

        [JsonIgnore]
        [Key]
        public long ProductId { get; set; }

        [JsonPropertyName("sku")]
        [Required(ErrorMessage = "O campo sku é obrigatório.")]
        public long Sku { get; set; }

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonPropertyName("inventory")]
        public Inventory Inventory { get; set; }

        [JsonPropertyName("isMarketable")]
        [NotMapped]
        public bool IsMarketable
        {
            get
            {
                return this.Inventory.Quantity > 0;
            }
        }
    }
}
