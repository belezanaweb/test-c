using System;
using System.Collections.Generic;

namespace BrunoTragl.BelezaNaWeb.Domain.Model
{
    public class Inventory
    {
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
