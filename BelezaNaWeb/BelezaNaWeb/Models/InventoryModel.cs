using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelezaNaWeb.Models
{
    public class InventoryModel
    {
        public int quantity
        {
            get
            {
                return listOfWarehouses.Sum(x => x.quantity);
            }
        }

        public List<WarehouseModel> listOfWarehouses { get; set; }

        public InventoryModel() { }

        public InventoryModel(List<WarehouseModel> warehouses)
        {
            this.listOfWarehouses = warehouses;
        }
    }
}