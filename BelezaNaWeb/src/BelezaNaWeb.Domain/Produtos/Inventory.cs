using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Produtos
{
    class Inventory
    {
        public long Quantity { get; set; }
        public Warehouse[] Warehouses { get; set; }
    }
}
