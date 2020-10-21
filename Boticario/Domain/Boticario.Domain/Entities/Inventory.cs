using System.Collections.Generic;
using System.Linq;

namespace Boticario.Domain.Entities
{
    public class Inventory
    {
        public int Quantity
        {
            get { return Warehouses?.Sum(q => q.Quantity) ?? 0; }
        }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
