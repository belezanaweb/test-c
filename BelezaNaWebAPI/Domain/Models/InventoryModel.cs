using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class InventoryModel
    {
        public InventoryModel()
        {
            Warehouses = new List<WarehouseModel>();
        }
        public long Quantity { get; set; }
        public List<WarehouseModel> Warehouses { get; set; }
    }
}
