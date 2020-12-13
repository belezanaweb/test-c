using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class Product
    {
        protected Product()
        {
        }

        public Product(int sku, string name)
        {
            this.Sku = sku;
            this.Name = name;
        }

        public int Sku { get; private set; }
        public string Name { get; private set; }
    }
}
