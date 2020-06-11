using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public static class ProductRepository
    {
        static ProductRepository()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            using (var context = new ProductContext(options))
            {
                AddProduct(context);
                context.SaveChanges();
            }
        }

        private static void AddProduct(ProductContext context)
        {
            Product testeProduto1 = CreateProduct();

            context.Products.Add(testeProduto1);

            context.SaveChanges();
        }

        private static Product CreateProduct()
        {
            var warehouse1 = new Warehouse()
            {
                WharehousId = 1,
                Locality = "SP",
                Quantity = 12,
                Type = "ECOMMERCE"
            };

            var warehouse2 = new Warehouse()
            {
                WharehousId = 2,
                Locality = "MOEMA",
                Quantity = 3,
                Type = "PHYSICAL_STORE"
            };

            var inventory = new Inventory()
            {
                InventoryId = 1,
                Warehouses = new Collection<Warehouse>()
            };

            inventory.Warehouses.Add(warehouse1);
            inventory.Warehouses.Add(warehouse2);

            var testeProduto1 = new Models.Product
            {
                ProductId = 1,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Sku = 43264,
                Inventory = inventory
            };
            return testeProduto1;
        }

        internal static void InsertProduct(Product product)
        {
            using (var context = new ProductContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static List<Product> GetProduct()
        {
            //using (var context = new ProductDbContext())
            //{
            //    // AddProduct(context);
            //    //return context.Products.ToList();

            //}

            var list = new List<Product>();
            list.Add(CreateProduct());
            return list;
        }

        public static Product GetProductBySku(int sku)
        {
            using (var context = new ProductContext())
            {
                return context.Products.Where(x => x.Sku == sku).SingleOrDefault();
            }
        }

        internal static object UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
