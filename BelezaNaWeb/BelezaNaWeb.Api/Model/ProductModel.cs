using BelezaNaWeb.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Model
{
    public class ProductModel
    {
        
        [Key]
        public int Sku { get; set; }
        
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