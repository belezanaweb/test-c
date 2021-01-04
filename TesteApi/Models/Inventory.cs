using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApi.Models
{
    public class Inventory
    {         
        public Guid Id { get; set; }    
        public int Quantity { get; set; }
        public IEnumerable<Warehouse> Warehouses { get; set; }       
    }
}
