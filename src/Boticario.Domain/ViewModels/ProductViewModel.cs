using System;
using System.ComponentModel.DataAnnotations;

namespace Boticario.Domain.ViewModels
{
    public class ProductViewModel
    {

        [Range(1, int.MaxValue, ErrorMessage = "Sku deve ser um valor entre 1 e 2147483647")]
        [Required(ErrorMessage = "Campo Sku é obrigatório")]
        public int Sku { get;  set; }

        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get;  set; }

        public InventoryViewModel Inventory { get; set; }

    }
}
