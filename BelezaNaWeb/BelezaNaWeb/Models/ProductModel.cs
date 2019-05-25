using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelezaNaWeb.Models
{
    public class ProductModel
    {
        public int sku { get; set; }
        public string name { get; set; }
        public InventoryModel inventory { get; set; }
        public bool isMarketable
        {
            get
            {
                return (inventory.quantity > 0);
            }
        }

        public ProductModel() { }

        public ProductModel(int sku, string name, InventoryModel inventory)
        {
            this.sku = sku;
            this.name = name;
            this.inventory = inventory;
        }
    }
}