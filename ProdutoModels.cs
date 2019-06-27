using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebApi.Models
{
    public class ProdutoModels
    {
        public int sku { get; set; }
        public string name { get; set; }
        public EstoqueModels Inventory { get; set; }
        public bool IsMarketable { get; set; }

    }
}