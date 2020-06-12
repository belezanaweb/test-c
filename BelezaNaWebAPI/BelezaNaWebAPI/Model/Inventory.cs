using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWebAPI.Model
{
    public class Inventory
    {
        public int quantity { get; set; }
        public IList<Warehouse> warehouses { get; set; }
    }
}
