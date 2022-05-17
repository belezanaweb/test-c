using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.domain.Entities
{
    public class Inventory
    {
        public List<Warehouse>? warehouses { get; set; }
    }
}
