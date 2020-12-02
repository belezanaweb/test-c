using BelezaNaWeb.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Model
{
    public class ProductModel
    {
        
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "Sku deve ser um valor entre 1 e 2147483647")]
        public int Sku { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }
        public InventoryModel Inventory { get; set; }

        public ProductModel() { }

        public ProductModel(int sku, string name, InventoryModel inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }
    }
}