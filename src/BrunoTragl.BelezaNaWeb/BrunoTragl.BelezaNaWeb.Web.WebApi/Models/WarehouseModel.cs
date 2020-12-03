using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Models
{
    public class WarehouseModel
    {
        [Required(ErrorMessage = "The field locality is required")]
        public string Locality { get; set; }
        
        [Required(ErrorMessage = "The field quantity is required")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "The field type is required")]
        public string Type { get; set; }
    }
}
