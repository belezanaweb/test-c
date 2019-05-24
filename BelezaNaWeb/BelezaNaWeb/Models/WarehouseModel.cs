using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelezaNaWeb.Models
{
    public class WarehouseModel
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }

        public WarehouseModel() { }

        public WarehouseModel(string locality, int quantity, string type)
        {
            this.locality = locality;
            this.quantity = quantity;
            this.type = type;
        }
    }
}