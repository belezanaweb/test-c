using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Models
{    
    public class Inventory
    {

        public int id { get; set; }
        public int quantity
        {
            get { 
                return warehouses.Sum(i => i.quantity);
            }
        }


        public List<Warehouse> warehouses { get; set; } = new List<Warehouse>();
                
    }
}
