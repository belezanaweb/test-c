using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Domain.Entities
{
    public class Inventory : Entity
    {

        public Inventory(){}

        public Inventory(List<Warehouses> warehouses, Product product)
        {
            Warehouses = new List<Warehouses>();
            Warehouses = warehouses;
            Product = new Product();
            Product = product;            
        }

        [NotMapped]
        public int Quantity { get { return QuantityInventory();} set { } }
        public List<Warehouses> Warehouses { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; private set; }

        public int QuantityInventory()
        { 
            var quantity = 0;      
            
            foreach (var warehouse in Warehouses)
            {
                quantity += warehouse.Quantity;
            }

            return quantity;

        }
    }
}
