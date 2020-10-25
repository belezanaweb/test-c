using Boticario.Backend.Modules.Products.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Implementation.Models
{
    internal class ProductDetails : IProductDetails
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public IProductInventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }

    internal class ProductInventory : IProductInventory
    {
        public long Quantity { get; set; }
        public IList<IProductInventoryDetails> Warehouses { get; set; }
    }

    internal class ProductInventoryDetails : IProductInventoryDetails
    {
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
    }
}
