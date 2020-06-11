using Microsoft.VisualBasic;
using ProductAPI.Context;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProductAPIxUnitTest
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        {}

        public void Seed(ProductContext context)
        {
            var warehouse1 = new Collection<Warehouse>();

            warehouse1.Add(new Warehouse { InventoryId = 11, Locality = "SP", Quantity = 2, Type = "ECOMMERCE" });
            context.Products.Add(new Product { 
                ProductId = 10, 
                Sku = 10,
                Name = "Product 10", 
                Inventory = new Inventory { 
                    InventoryId = 11, 
                    Warehouses = warehouse1 
                } 
            });

            var warehouse2 = new Collection<Warehouse>();

            warehouse1.Add(new Warehouse { InventoryId = 12, Locality = "SP", Quantity = 3, Type = "ECOMMERCE" });
            context.Products.Add(new Product
            {
                ProductId = 20,
                Sku = 20,
                Name = "Product 20",
                Inventory = new Inventory
                {
                    InventoryId = 12,
                    Warehouses = warehouse2
                }
            });

        }
    }
}
