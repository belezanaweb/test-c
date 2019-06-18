using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.Domain
{
    public class Inventory
    {
        public int Quantity { get; set ; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
