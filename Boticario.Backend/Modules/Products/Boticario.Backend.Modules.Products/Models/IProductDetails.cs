using Boticario.Backend.Modules.Inventory.Models;

namespace Boticario.Backend.Modules.Products.Models
{
    public interface IProductDetails
    {
        int Sku { get; }
        string Name { get; }
        IInventoryDetails Inventory { get; }
        bool IsMarketable { get; }
    }
}
