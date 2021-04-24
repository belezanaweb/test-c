using System.ComponentModel.DataAnnotations;

namespace Boticario.Api.ViewModels
{
    public class ProductViewModel
    {
        #region Attributes

        [Required(ErrorMessage = "Campo Sku é obrigatório")]
        public uint sku { get; set; }

        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string name { get; set; }

        public InventoryViewModel inventory { get; set; }

        public bool isMarketable { get; set; }

        #endregion
    }
}