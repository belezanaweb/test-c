using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Application.ViewModels
{
    public class WarehouseViewModel
    {
        [Required(ErrorMessage = "The Locality is Required")]
        public string Locality { get; set; }
        [Required(ErrorMessage = "The Quantity is Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "The Type is Required")]
        public string Type { get; set; }
    }
}
