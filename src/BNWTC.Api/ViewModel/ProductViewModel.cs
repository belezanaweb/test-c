using System.ComponentModel.DataAnnotations;

namespace BNWTC.Api.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sku { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} deve conter entre 3 e 250 caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        public InventoryViewModel Inventory { get; set; }

        public bool IsMarketable { get; set; }
    }
}
