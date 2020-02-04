using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Domain.Produtos
{
    public class Inventory
    {
        public long Quantity { get; private set; }
        public List<Warehouse> Warehouses { get; private set; } = new List<Warehouse>();

        internal void CalcularQuantity()
        {
            this.Quantity = this.Warehouses.Sum(p => p.Quantity);
        }
    }
}
