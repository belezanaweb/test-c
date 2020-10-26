using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Factories
{
    public interface IProductFactory
    {
        IProductEntity CreateEntity(int sku, string name);
        IProductDetails CreateDetails(IProductEntity entity, IInventoryDetails inventoryDetails);
    }
}
