using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities
{
    public class Inventory : BaseEntity
    {
        public int Quantity => GetQuantity();
        public virtual List<Warehouse> Warehouses { get; set; }

        public Inventory()
        {
            this.Warehouses = new List<Warehouse>();
        }

        public int GetQuantity()
        {
            if (Warehouses is null)
                return 0;

            return Warehouses.Sum(x => x.Quantity);
        }
    }
}
