using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Core.Model
{
    public class Inventory
    {
        public int Quantity
        {
            get
            {
                return Warehouses?.Sum(q => q.Quantity) ?? 0;
            }

            
        }

        public List<Warehouse> Warehouses { get; set; }
    }
}