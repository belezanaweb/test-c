using System.ComponentModel.DataAnnotations;

namespace TestC.Models
{
    public class Product {

        public Product()
        {
            this.inventory = new Inventory();
        }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid sku.")]
        public int sku { get; set; }

        [Required(ErrorMessage = "Product name is required.", AllowEmptyStrings = false)]
        public string name { get; set; } 

        public Inventory inventory { get; set; } 

        public bool isMarketable { get { return inventory == null ? false : inventory.quantity > 0; } } 
    }
}