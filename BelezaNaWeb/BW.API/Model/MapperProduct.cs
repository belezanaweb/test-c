using System;
using System.Collections.Generic;
using System.Linq;

namespace BW.API.Model
{
    public class MapperProduct
    {
        public Domain.ProductDomain MapperRequestToDomain(ProductRequest request)
        {
            var productDomain = new Domain.ProductDomain
            {
                Name = request.Name,
                Sku = request.Sku,
                IsMarketable = false,
                Inventory = new Domain.InventoryDomain
                {
                    Warehouses = new List<Domain.WarehouseDomain>()
                }
            };

            if (request.Inventory!=null)
            {
                if (request.Inventory.Warehouses.Any())
                {
                    request.Inventory.Warehouses.ToList().ForEach(x =>
                    {
                        productDomain.Inventory.Warehouses.Add(new Domain.WarehouseDomain
                        {
                            Locality = x.Locality,
                            Quantity = new Random().Next(0, 9000),//adiciona quantidades ficticias..
                            Type = x.Type
                        });
                    });
                }

                //  Um produto é marketable sempre que seu inventory.quantity for maior que 0
                if (productDomain.Inventory.Warehouses.Any(x=> x.Quantity > 0))
                {
                    productDomain.IsMarketable = true;
                }
            }            
            return productDomain;
        }
    }


   
}
