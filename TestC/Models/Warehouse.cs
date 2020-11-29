using System.IO;
using System.ComponentModel.DataAnnotations;

namespace TestC.Models
{
    public class Warehouse {

        [Required(ErrorMessage = "Warehouse locality is required.", AllowEmptyStrings = false)]
        public string locality { get; set; } 

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid quantity.")]
        public int quantity { get; set; } 

        [Required(ErrorMessage = "Warehouse type is required.", AllowEmptyStrings = false)]
        public string type { get; set; } 
    }
}