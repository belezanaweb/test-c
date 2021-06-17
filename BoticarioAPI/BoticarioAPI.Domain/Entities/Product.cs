using System.Collections.Generic;

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
        public virtual List<Warehouse> Warehouses { get; set; }

        public void Update(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }
    }
}
