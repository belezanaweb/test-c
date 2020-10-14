using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class StockKeepingUnit
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }

    }
}
