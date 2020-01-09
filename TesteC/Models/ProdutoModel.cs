using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteC.Models
{
    public class ProdutoModel
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Invetory invetory { get; set; }
        public bool isMarketable { get; set; }
    }

    public class Invetory
    {
        public int quantity { get; set; }
        public List<Warehouses> warehouses { get; set; }


    }

    public class Warehouses
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}
