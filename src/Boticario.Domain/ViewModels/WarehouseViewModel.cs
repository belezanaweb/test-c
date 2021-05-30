using System.ComponentModel.DataAnnotations;

namespace Boticario.Domain.ViewModels
{
    public class WarehouseViewModel
    {

        [Required(ErrorMessage = "Locality é obrigatório")]
        public string Locality { get;  set; }
        public double Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Type é obrigatório")]
        public string  Type { get;  set; }
    }
}
