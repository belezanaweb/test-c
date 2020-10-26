using Boticario.Backend.Modules.Inventory.Models;
using Boticario.Backend.Modules.Products.BusinessLogic;
using Boticario.Backend.Modules.Products.Factories;
using Boticario.Backend.Modules.Products.Implementation.BusinessLogic;
using Boticario.Backend.Modules.Products.Implementation.Exceptions;
using Boticario.Backend.Modules.Products.Implementation.Models;
using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Implementation.Factories
{
    public class DefaultProductFactory : IProductFactory
    {
        private readonly IMarketableCalculator marketableCalculator;

        public DefaultProductFactory()
        {
            this.marketableCalculator = new DefaultMarketableCalculator();
        }

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

        public IProductDetails CreateDetails(IProductEntity entity, IInventoryDetails inventoryDetails)
        {
            return new ProductDetails()
            {
                Sku = entity.Sku,
                Name = entity.Name,
                IsMarketable = this.marketableCalculator.Calc(inventoryDetails),
                Inventory = inventoryDetails
            };
        }
    }
}
