
using System.Collections.Generic;

namespace TesteBoticario.Domain.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
