using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Domain.Entities
{
    public class Product : Entity
    {
        public Product()
        {
                
        }

        public Product(int sku, string name, Inventory inventory)
        {
            this.Sku = sku;
            this.Name = name;
            this.Inventory = new Inventory(inventory?.Warehouses, this);            
        }

        public int Sku { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public bool IsMarketable { get { return Inventory?.Quantity > 0; } }
        public Inventory Inventory { get; set; }


        public void UpdateProduct(string name, Inventory inventory)
        {           
            this.Name = name;
            this.Inventory = new Inventory(inventory.Warehouses, this);
        }
    }
}
