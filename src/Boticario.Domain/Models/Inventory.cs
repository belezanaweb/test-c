using System.Collections.Generic;
using System.Linq;

namespace Boticario.Domain.Models
{
    public class Inventory
    {
        public Inventory()
        {
            this.Warehouses = new List<Warehouses>();
        }

        public void TotalizeQuantity()
        {
            this.Quantity = Warehouses != null ? Warehouses.Sum(x => x.Quantity) : 0;
        }

        public void AddWarehouse(Warehouses wareHouse)
        {
            if (wareHouse != null)
                Warehouses.Add(wareHouse);
        }

        public double Quantity { get; private set; }
        public IList<Warehouses> Warehouses { get; private set; }

    }
}
