namespace Inventory.Domain.Events
{
    public class ProductRemoved : NetHacksPack.Core.ObjectEvent
    {
        public ProductRemoved(long sku)
        {
            Sku = sku;
        }

        public long Sku { get; }
    }
}
