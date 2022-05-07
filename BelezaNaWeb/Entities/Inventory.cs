using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BelezaNaWeb.Entities
{
    public class Inventory
    {
        public Inventory()
        {
            warehouses = new List<Warehouse>();
        }
        public int quantity { get { return this.warehouses.Sum(item => item.quantity); } }

        [Required]
        public List<Warehouse> warehouses { get; set; }
    }
}
