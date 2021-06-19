using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Api.Model.Entities
{
    public class Inventory : Entity
    {
        public int Quantity
        {
            get
            {
                return Warehouses is null ? 0 : Warehouses.Sum(x => x.Quantity);
            }
        }
        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
