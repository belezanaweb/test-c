using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApi.Models
{
    public class Warehouse
    {
        public Guid Id { get; set; }  
        public int ProductId { get; set; }
        public Inventory Inventory { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }

}
