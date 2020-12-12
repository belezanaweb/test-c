using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Produto
    {


        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }

    }
}