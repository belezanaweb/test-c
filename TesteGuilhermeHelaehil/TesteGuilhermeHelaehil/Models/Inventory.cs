using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteGuilhermeHelaehil.Models
{
    public class Inventory
    {
        public int? quantity {
            //calcula o valor de inventory.quantity usando a variavel quantity de cada warehouse
            get
            {
                if (warehouses == null)
                    return 0;
                return warehouses.Sum(o => o.quantity);
            }
        }
        public Warehouse[] warehouses { get; set; }
    }
}
