using Inventory.Core;

namespace Inventory.Domain.Events
{
    public class ProductUpdated : NetHacksPack.Core.ObjectEvent
    {
        private readonly Product data;

        public static implicit operator Product(ProductUpdated product)
        {
            product.data.CalculateInventory();
            return product.data;
        }

        public ProductUpdated(Product product)
        {
            this.data = product;
        }
    }
}
