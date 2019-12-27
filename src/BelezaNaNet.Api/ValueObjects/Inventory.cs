using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BelezaNaNet.Api.ValueObjects
{
    public class Inventory
    {
        protected Inventory()
        {

        }
        public Inventory(IList<Warehouse> warehouses)
        {
            Warehouses = warehouses;
            Quantity = Warehouses.Sum(p => p.Quantity);
        }
        public int Quantity { get; private set; } = 0;
        public IList<Warehouse> Warehouses { get; private set; } = new List<Warehouse>();
    }
}
