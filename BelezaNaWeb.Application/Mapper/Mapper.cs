using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModels;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Models;
using System;
using System.Collections.Generic;

namespace BelezaNaWeb.Application.Mapper
{
    public class Mapper : IMapper
    {
        private readonly IWarehouseRepository warehouseRepository;

        public Mapper(IWarehouseRepository warehouseRepository)
        {
            this.warehouseRepository = warehouseRepository;
        }
        
        public ProductViewModel Map(Product product)
        {
            if (product == null)
                return null;
            
            ProductViewModel productViewModel = new ProductViewModel
            {
                Name = product.Name,
                Sku = product.Sku,
                Inventory = new InventoryViewModel()
            };

            foreach(var inventory in product.Inventory)
            {
                productViewModel.Inventory.Warehouses.Add(new WarehouseViewModel() 
                { 
                    Locality = inventory.Warehouse.Locality,
                    Quantity = inventory.Quantity,
                    Type = inventory.Warehouse.Type
                });
            }

            return productViewModel;
        }

        public Product Map(ProductViewModel productViewModel)
        {
            if (productViewModel == null)
                return null;

            List<Inventory> inventory = new List<Inventory>();
            Product product = new Product(productViewModel.Sku, productViewModel.Name, inventory);
            
            foreach(var warehouseViewModel in productViewModel.Inventory.Warehouses)
            {
                var warehouse = warehouseRepository.Get(warehouseViewModel.Locality, warehouseViewModel.Type.ToString());
                if(warehouse == null)
                {
                    warehouse = new Warehouse(warehouseViewModel.Locality, warehouseViewModel.Type);
                    warehouseRepository.Add(warehouse);
                }
                inventory.Add(new Inventory(product.Id, warehouse.Id, warehouseViewModel.Quantity));
            }

            return product;
        }
    }
}
