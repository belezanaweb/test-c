using BelezaNaWebDomain.Entities;
using System.Collections.Generic;

namespace BelezaNaWebDomain
{
    public class Inventory : EntityBase
    {
        public Inventory()
        {
        }

        public virtual Product Product { get; set; }

        public string ProductId { get; set; }

        public virtual List<Warehouse> Warehouses { get; set; }
    }
}