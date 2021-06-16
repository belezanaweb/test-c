using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBelezaNaWeb.API.Core.Entities;

namespace TesteBelezaNaWeb.API.Models.ViewModel
{
    public class InventoryViewModel
    {
        public int quantity { get { return warehouses == null ? 0 : warehouses.Sum(t => t.quantity); } }

        public IList<WarehouseViewModel> warehouses { get; private set; }



    }
}
