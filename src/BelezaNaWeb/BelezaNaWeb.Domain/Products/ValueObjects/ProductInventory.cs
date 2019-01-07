using System;
using System.Collections.Generic;
using System.Linq;
using BelezaNaWeb.Domain.Products.Enums;
using BelezaNaWeb.Domain.Products.Exceptions;

namespace BelezaNaWeb.Domain.Products.ValueObjects
{
    public class ProductInventory
    {
        public long Quantity 
        {
            get
            {
                return _warehouses.Sum(w => w.Value.Quantity);
            }
        }

        private IDictionary<string, ProductInventoryWarehouse> _warehouses;
        public IDictionary<string,ProductInventoryWarehouse> Warehouses 
        { 
            get
            {
                return new Dictionary<string, ProductInventoryWarehouse>(_warehouses);
            }

        }

        public ProductInventory()
        {
            _warehouses = new Dictionary<string, ProductInventoryWarehouse>();
        }

        public void Add(string warehouseName, ProductInventoryWarehouseType type)
        {
            var quantity = 1;
            if(_warehouses.ContainsKey(warehouseName))
            {
                var warehouse = _warehouses[warehouseName];
                quantity = warehouse.Quantity + 1;
            }

            AddOrUpdate(warehouseName, type, quantity);
        }

        public void AddOrUpdate(string warehouseName, ProductInventoryWarehouseType type, int quantity)
        {
            if (quantity < 0)
                throw new InvalidProductWarehouseNameException();

            if (string.IsNullOrEmpty(warehouseName))
                throw new InvalidProductWarehouseNameException();

            if (!_warehouses.ContainsKey(warehouseName))
            {
                _warehouses[warehouseName] = new ProductInventoryWarehouse(warehouseName, quantity, type);
            }
            else
            {
                var warehouse = _warehouses[warehouseName];
                _warehouses[warehouseName] = new ProductInventoryWarehouse(warehouseName, quantity, type);
            }
        }

        public void Remove(string warehouseName)
        {
            if (!_warehouses.ContainsKey(warehouseName))
                throw new ProductWarehouseNotFoundForDeletionException();

            _warehouses.Remove(warehouseName);
        }
    }
}
