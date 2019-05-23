using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlzWeb.Domain.StoreContext.Entities
{
    public sealed class Inventory : Notifiable
    {
        private readonly IList<Warehouse> _warehouses;

        public Inventory(decimal quantity)
        {
            Quantity = quantity;
            _warehouses = new List<Warehouse>();
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
        }

        public decimal Quantity { get; private set; }
        public IReadOnlyCollection<Warehouse> Warehouses => _warehouses.ToArray();

        internal void CalculateInventory()
        {
            Quantity = Warehouses.Sum(c => c.Quantity);
        }
    }
}
