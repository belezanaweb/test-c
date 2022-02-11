using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Model
{
    public class Product
    {
        public Product(int sku, string name, Inventory inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        public int Sku { get; private set; }

        public string Name { get; private set; }

        public Inventory Inventory { get; private set; }

        public bool IsMarketable => Inventory.Quantity > 0;
    }
}
