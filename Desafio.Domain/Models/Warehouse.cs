using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class Warehouse
    {
        protected Warehouse()
        { 
        }

        public Warehouse(int sku, string locality, int quantity, string type)
        {
            this.Sku = sku;
            this.Locality = locality;
            this.Quantity = quantity;
            this.Type = type;
        }

        public int Sku { get; private set; }
        public string Locality { get; private set; }
        public int Quantity { get; private set; }
        public string Type { get; private set; }
    }
}
