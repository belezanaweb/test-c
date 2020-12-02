using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        #region Construtores 

        public Inventory() { }

        public Inventory (int quantity, List<Warehouse> warehouses)
        {
            Quantity = quantity;
            Warehouses = warehouses;
        }

        #endregion 
    }
}
