using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Inventory = new InventoryModel();
        }
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryModel Inventory { get; set; }
        public bool IsMarketable { get; set; }

        public ProductModel Build()
        {
            Inventory.Quantity = Inventory.Warehouses.Sum(x => x.Quantity);
            IsMarketable = Inventory.Quantity > 0 ? true : false;

            return this;
        }
    }
}
