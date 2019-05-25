using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelezaNaWeb.Models
{
    public class ProductModel
    {
        public int skuCode { get; set; }
        public string productName { get; set; }
        public InventoryModel productInventory { get; set; }
        public bool isMarketable
        {
            get
            {
                return (productInventory.quantity > 0);
            }
        }

        public ProductModel() { }
    }
}