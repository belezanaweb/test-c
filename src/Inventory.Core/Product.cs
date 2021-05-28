using Inventory.Core.Exceptions;
using System.Linq;

namespace Inventory.Core
{
    public class Product
    {
        public Product()
        {

        }

        public Product(long sku, string name, Inventory inventory, bool isMarketable)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
            IsMarketable = isMarketable;
        }

        public long Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public Inventory Inventory { get; set; }

        public void CalculateInventory()
        {
            if (Inventory == null)
                throw new InvalidInventoryException(this.Sku);
            if (Inventory.Warehouses == null)
                throw new InvalidWarehouseException(this.Sku);
            this.Inventory.Quantity = Inventory.Warehouses.Sum(s => s.Quantity);
            this.IsMarketable = this.Inventory.Quantity > 0;
        }
    }
}
