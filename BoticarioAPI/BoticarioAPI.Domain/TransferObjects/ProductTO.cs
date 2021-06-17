using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Domain.TransferObjects
{
    public class ProductTO
    {
        public ProductTO(int sku, string name, List<WarehouseTO> warehouses)
        {
            Sku = sku;
            Name = name;

            if (warehouses.Count > 0)
            {
                int quantity = warehouses.Sum(warehouse => warehouse.Quantity);
                Inventory = new InventoryTO(quantity, warehouses);
                IsMarketable = quantity > 0;
            }
            else
            {
                Inventory = new InventoryTO(0, new List<WarehouseTO>());
                IsMarketable = false;
            }
        }

        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryTO Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
