using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoBoticario.Data
{
    public class Inventory
    {
        [Key]
        public int Sku { get; set; }
        public int Quantity
        {
            get
            {
                return Warehouses.Any() ? Warehouses.Sum(p => p.Quantity) : 0;
            }
        }
        public IEnumerable<Warehouse> Warehouses { get; set; }

    }
}