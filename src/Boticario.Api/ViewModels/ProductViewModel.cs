using System.ComponentModel.DataAnnotations;

namespace Boticario.Api.ViewModels
{
    public class ProductViewModel
    {
        #region Properties

        [Range(1, uint.MaxValue, ErrorMessage = "Sku deve ser um valor entre 1 e 4294967295")]
        [Required(ErrorMessage = "Campo Sku é obrigatório")]
        public uint Sku { get; set; }

        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }

        public InventoryViewModel Inventory { get; set; }

        public bool IsMarketable { get; set; }

        #endregion
    }
}