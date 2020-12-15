using System.Collections.Generic;
using System.Linq;

namespace TesteBoticario.Domain.Dto
{
    public class Inventory
    {
        //public Inventory(IEnumerable<Warehouse> warehouses)
        //{
        //    Warehouses = warehouses;
        //}

        public int Quantity => Warehouses?.Sum(q => q.Quantity) ?? 0;

        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}