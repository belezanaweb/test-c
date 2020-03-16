using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Queries {
    public class InventoryResult {
        public List<WarehouseResult> warehouses { get; set; } = new List<WarehouseResult>();
        public int quantity { get; set; }
    }
}
