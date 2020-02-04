using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Produtos
{
    class Produto
    {

        public long Sku { get; set; }

        public string Name { get; set; }

        public Inventory Inventory { get; set; }

        public bool? IsMarketable { get; set; }
    }
}
