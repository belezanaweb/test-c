using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.API.Models
{
    public class Inventory
    {
        public long Quantity 
        {
            get 
            {
                return WareHouses.Sum(x => x.Quantity); 
            }
        }

        public List<WareHouse> WareHouses { get; set; }
    }
}
