using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beleza.Na.Web.Domain
{
    public class ProductDomain
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public Inventory Inventory { get; set; }
    }
}
