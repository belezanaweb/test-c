using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Models
{
    public class Warehouse
    {
        public int id { get; set; }
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }        
    }
}
