using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Application.ViewModel
{
    public class ProdutoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "O SKU do produto é obrigatório")]
        public long Sku { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatorio")]
        public string Name { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public bool IsMarkatable 
        {
            get => Inventory?.Quantidade > 0;
        }
    }
}
