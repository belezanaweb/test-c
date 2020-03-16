using BelezaNaWeb.Domain.Core.Models;

namespace BelezaNaWeb.Domain.Models
{
    public class Inventory : Entity
    {
        public Inventory(int idProduct, int idWarehouse, int quantity)
        {
            IdProduct = idProduct;
            IdWarehouse = idWarehouse;
            Quantity = quantity;
        }
        
        protected Inventory() 
        {
        }

        public int IdProduct { get; private set; }
        public int IdWarehouse { get; private set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; private set; }
        public virtual Warehouse Warehouse { get; private set; }
    }
}
