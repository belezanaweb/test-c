using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.TestC.Api.Models
{
    public class Inventory
    {
        public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public int Quantity => Warehouses.Sum(p => p.Quantity);
    }
}
