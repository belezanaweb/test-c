using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteGuilhermeHelaehil.Models
{
    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public bool isMarketable
        {
            //calcula o valor de isMarketable usando a variavel quantity do objeto inventory
            get {
                if (inventory == null)
                    return false;
                return inventory.quantity > 0;
            }
        }
        public Inventory inventory { get; set; }

        
    }
}
