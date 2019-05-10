using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Domain
{
    public class Inventory
    {
        public int Quantity {
            get
            {
                return Warehouses.Sum(x => x.Quantity);
            }
       }

        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}
