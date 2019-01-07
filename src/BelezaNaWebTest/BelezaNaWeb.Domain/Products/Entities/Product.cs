using System;
using BelezaNaWeb.Domain.Products.Enums;
using BelezaNaWeb.Domain.Products.ValueObjects;

namespace BelezaNaWeb.Domain.Products.Entities
{
    public class Product
    {
        public long Sku { get; private set; }
        public string Name { get; private set; }
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

        public void Add(string wharehouseName, ProductInventoryWarehouseType type)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(string wharehouseName, ProductInventoryWarehouseType type, int newQuantity)
        {
            throw new NotImplementedException();
        }

        public void Remove(string warehouseName)
        {
            throw new NotImplementedException();
        }
    }
}
