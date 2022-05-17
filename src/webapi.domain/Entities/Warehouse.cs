using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.domain.Entities
{
    public  class Warehouse
    {
        public string? locality { get; set; }
        public int quantity { get; set; }

        public string? type { get; set; }
    }
}
