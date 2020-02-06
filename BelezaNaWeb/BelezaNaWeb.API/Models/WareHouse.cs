using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.API.Models
{
    public class WareHouse
    {
        [Required]
        public string Locality { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
