using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.API.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Nome { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                if (Inventory == null || Inventory.Quantity == 0)
                    return false;
                else if (Inventory.Quantity > 0)
                    return true;

                return false;
            }
        }
       
    }
}
