using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.Models
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
