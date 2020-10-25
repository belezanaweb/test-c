using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Models;
using System.Collections.Generic;

namespace Boticario.Backend.Modules.Products.Factories
{
    public interface IProductFactory
    {
        IProductEntity CreateEntity(int sku, string name);
        IProductDetails CreateProductDetails(IProductEntity entity, IList<IInventoryEntity> inventories);
    }
}
