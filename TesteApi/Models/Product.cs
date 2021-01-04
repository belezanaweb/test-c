using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApi.Models
{
    public class Product
    {        
        public int Sku { get; set; }
        public string Name { get; set; } 
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
