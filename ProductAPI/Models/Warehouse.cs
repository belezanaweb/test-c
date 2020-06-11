using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public class Warehouse
    {
        [JsonIgnore]
        [Key]
        public int WharehousId { get; set; }

        [JsonPropertyName("locality")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Locality { get; set; }

        [JsonPropertyName("quantity")]
        [Required(ErrorMessage = "Campo obrigatório.")] 
        public int Quantity { get; set; }

        [JsonPropertyName("type")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Type { get; set; }

        public int InventoryId { get; set; }


    }
}
