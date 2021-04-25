using System.ComponentModel.DataAnnotations;

namespace Boticario.Api.ViewModels
{
    public class ProductViewModel
    {
        #region Attributes

        [Range(1, uint.MaxValue, ErrorMessage = "Sku deve ser um valor entre 1 e 4294967295")]
        [Required(ErrorMessage = "Campo Sku é obrigatório")]
        public uint sku { get; set; }

        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string name { get; set; }

        public InventoryViewModel inventory { get; set; }

        public bool isMarketable { get; set; }

        #endregion
    }
}