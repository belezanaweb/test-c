using Belezanaweb.Domain.Core.Entities;

namespace Belezanaweb.Domain.Products.Entity
{
    public class Product : EntityBase
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
    }
}
