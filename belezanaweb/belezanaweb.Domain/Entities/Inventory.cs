using System;
using System.Collections.Generic;
using System.Linq;

namespace belezanaweb.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Quantity
        {
            get
            {
                if (Warehouses == null)
                    return 0;
                return Warehouses.Sum(w => w.Quantity);
            }            
        }
        public virtual List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}