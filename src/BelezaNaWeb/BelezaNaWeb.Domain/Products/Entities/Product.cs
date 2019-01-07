using BelezaNaWeb.Domain.Products.Exceptions;
using BelezaNaWeb.Domain.Products.ValueObjects;

namespace BelezaNaWeb.Domain.Products.Entities
{
    public class Product
    {
        private long _sku;
        public long Sku 
        { 
            get
            {
                return _sku;
            }

            private set
            {
                if (value <= 0)
                    throw new InvalidProductSkuException();

                _sku = value;
            }
        }

        private string _name;
        public string Name 
        { 
            get
            {
                return _name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidProductNameException();

                _name = value;
            }
        }
        public ProductInventory Inventory { get; private set; }
        public bool IsMarketable { 
            get
            {
                return Inventory.Quantity > 0;
            }
        }

        public Product(long sku, string name, ProductInventory inventory = null)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory ?? new ProductInventory();
        }
    }
}
