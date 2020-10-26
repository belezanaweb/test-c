using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Implementation.Models
{
    internal class ProductDetails : IProductDetails
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public IInventoryDetails Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}
