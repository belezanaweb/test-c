using Inventory.Core;

namespace Inventory.Domain.Events
{
    public class ProductCreated : NetHacksPack.Core.ObjectEvent
    {
        private readonly Product data;

        public static implicit operator Core.Product(ProductCreated product)
        {
            return product.data;
        }

        public ProductCreated(Core.Product product)
        {
            this.data = product;
        }
    }
}
