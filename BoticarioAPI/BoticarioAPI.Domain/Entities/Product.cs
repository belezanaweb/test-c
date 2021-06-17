using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.Entities
{
    public class Product
    {
        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        public int Id { get; private set; }
        public int Sku { get; private set; }
        public string Name { get; private set; }
        public virtual List<Warehouse> Warehouses { get; private set; }

        public void Update(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }
    }
}
