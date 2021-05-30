using System;
using System.ComponentModel.DataAnnotations;

namespace Boticario.Domain.ViewModels
{
    public class ProductUpdateViewModel
    {

        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get;  set; }

        public InventoryViewModel Inventory { get; set; }

    }
}
