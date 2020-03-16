using BelezaNaWeb.Domain.Core.Models;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Models
{
    public class Product : Entity
    {
        public Product(int sku, string name, ICollection<Inventory> inventory) : this()
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        protected Product() 
        {
            Inventory = new HashSet<Inventory>();
        }

        public int Sku { get; private set; }

        public string Name { get; private set; }

        public ICollection<Inventory> Inventory { get; private set; }
    }
}
