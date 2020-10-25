using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.Factories;
using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Implementation.Models;
using Boticario.Backend.Modules.Products.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Backend.Modules.Products.Implementation.Factories
{
    public class DefaultProductFactory : IProductFactory
    {
        public IProductEntity CreateEntity(int sku, string name)
        {
            if (sku < 1)
            {
                throw new ProductValidationException("SKU is invalid!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductValidationException("Name is missing!");
            }

            return new ProductEntity()
            {
                Sku = sku,
                Name = name.Trim()
            };
        }

        public IProductDetails CreateProductDetails(IProductEntity entity, IList<IInventoryEntity> inventories)
        {
            return new ProductDetails()
            {
                Sku = entity.Sku,
                Name = entity.Name,
                Inventory = new ProductInventory()
                {
                    Warehouses = inventories.Select(p => (IProductInventoryDetails)new ProductInventoryDetails()
                    {
                        Locality = p.Locality,
                        Quantity = p.Quantity,
                        Type = p.Type
                    }).ToList()
                }
            };
        }
    }
}
