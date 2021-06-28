using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Models.Product
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }

        public IEnumerable<WareHouseViewModel> WareHouses { get; set; }
    }
}
