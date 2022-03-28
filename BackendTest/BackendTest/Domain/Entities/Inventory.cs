using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendTest.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get { return Warehouses.Sum(x => x.Quantity); } }
        public IEnumerable<Warehouse> Warehouses { get; set; }

        public void Atualizar(IEnumerable<Warehouse> warehouses)
        {
            Warehouses = warehouses;
        }
    }
}
