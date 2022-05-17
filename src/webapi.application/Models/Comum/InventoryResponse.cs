using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.application.Models.Comum
{
    public class InventoryResponse
    {
        public int quantity { get { return warehouses?.Count ?? 0; } }
        public List<WarehouseModel>? warehouses { get; set; }
    }
}
