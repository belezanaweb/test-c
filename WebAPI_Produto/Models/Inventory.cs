using System.Collections.Generic;
using System.Linq;

namespace WebAPI_Produto.Models
{
    public class Inventory
    {
        public int quantity { get; set; }
        public List<Warehouse> warehouses { get; set; }
    }
}