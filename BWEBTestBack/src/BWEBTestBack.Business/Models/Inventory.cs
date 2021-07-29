using System;
using System.Collections.Generic;

namespace BWEBTestBack.Business.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
