using System.Collections.Generic;

namespace Boticario.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public Inventory(int quantity, int idProduct)
        {
            Quantity = quantity;
            IdProduct = idProduct;
            Warehouses = new List<Warehouse>();
        }
        
        public int Quantity { get; private set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public List<Warehouse> Warehouses { get; private set; }
    }
}
