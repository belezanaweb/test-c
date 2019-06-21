using System;
using System.Threading.Tasks;

namespace BW.API.Model
{

    public class ProductRequest
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        //public bool IsMarketable { get; set; }

    }


   
}
