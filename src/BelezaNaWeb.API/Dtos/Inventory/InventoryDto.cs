using BelezaNaWeb.API.Dtos.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Dtos.Inventory
{
    public class InventoryDto
    {
        public IEnumerable<WareHouseDto> WareHouses { get; set; }
        public int Quantity 
        {
            get
            {
                return WareHouses.Sum(x => x.Quantity);
            }
        }
    }
}
