using Domain.Entites;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {

        public int Quantity
        {
            get
            {
                return Warehouses.Any() ? Warehouses.Sum(w => w.Quantity) : 0;
            }
        }
        public virtual ICollection<Warehouse> Warehouses { get; set; }

    }
}
