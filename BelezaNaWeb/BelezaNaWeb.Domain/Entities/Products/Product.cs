using System;

namespace BelezaNaWeb.Domain.Entities.Products
{
    public class Product : EntityBase
    {
        public Product(long sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        public long Sku { get; set; }

        public string Name { get; set; }

        public bool? IsMarketable
        {
            get
            {
                if (Inventory?.Quantity > 0)
                    return true;

                return false;
            }
        }

        public virtual Inventory Inventory { get; set; }

        public void Update(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            Name = product.Name;
            Inventory = product.Inventory;
        }
    }
}
