using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Inventory
    {
        public ICollection<Warehouse> warehouses { get; set; }
    }
}
