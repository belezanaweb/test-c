using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Domain.Entities.Products
{
    public class Inventory : EntityBase
    {
        private readonly List<Warehouse> _warehouse = new List<Warehouse>();
        
        public Inventory(long productSku, Product product)
        {
            ProductSku = productSku;
            Product = product;
        }

        public Inventory()
        {
        }

        public long ProductSku { get; set; }

        public long ProductId { get; set; }

        public int? Quantity
        {
            get
            {
                return Warehouses?.Sum(x => x.Quantity);
            }
        }

        public virtual Product Product { get; set; }
        
        public virtual List<Warehouse> Warehouses => _warehouse;

        public void AddWarehouse(Warehouse warehouse)
        {
            if (warehouse is null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            if (!Warehouses.Contains(warehouse))
            {
                _warehouse.Add(warehouse);
            }
        }
    }
}
