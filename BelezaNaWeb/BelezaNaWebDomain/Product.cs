using BelezaNaWebDomain.Entities;

namespace BelezaNaWebDomain
{
    public class Product : EntityBase
    {
        public long? SKU { get; set; }
        public string Name { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}