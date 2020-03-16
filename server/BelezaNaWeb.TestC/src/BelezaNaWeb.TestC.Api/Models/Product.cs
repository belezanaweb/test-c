using System;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.TestC.Api.Models
{
    public class Product
    {
        public uint Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        public bool IsMarketable => Inventory.Quantity > 0;

        public bool IsValid()
            => Sku > 0;
    }    
}
