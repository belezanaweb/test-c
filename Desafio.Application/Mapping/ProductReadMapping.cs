using Desafio.Application.ViewModels.Read;
using Desafio.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Application.Mapping
{
    public static class ProductReadMapping
    {
        public static ProductReadViewModel GetProduct(Product product, List<Warehouse> warehouseList)
        {
            if (product == null) 
                return null;

            var inventory = new InventoryReadViewModel { 
                Warehouses = warehouseList.Select(x => new WarehouseReadViewModel { 
                    Locality = x.Locality,
                    Quantity = x.Quantity,
                    Type = x.Type
                }).ToList(),
                Quantity = warehouseList.Sum(x => x.Quantity)
            };

            return new ProductReadViewModel { 
                Sku = product.Sku,
                Name = product?.Name,
                Inventory = inventory,
                IsMarketable = inventory.Quantity > 0

            };
        }

    }
}
