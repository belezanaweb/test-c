using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Domain.Products.ValueObjects
{
    public class ProductInventory
    {
        public int Quantity { get; }

        private IList<ProductInventoryWarehouse> _warehouses;
        public IList<ProductInventoryWarehouse> Warehouses 
        { 
            get
            {
                return _warehouses.ToList().AsReadOnly();
            }

        }

        public ProductInventory()
        {
            _warehouses = new List<ProductInventoryWarehouse>();
        }

        public ProductInventoryWarehouse GetByWarehouseName(string warehouseName)
        {
            return Warehouses.FirstOrDefault(w => w.Locality == warehouseName);
        }
    }
}
