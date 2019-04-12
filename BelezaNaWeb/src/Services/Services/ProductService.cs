using System;
using System.Collections.Generic;
using System.Linq;
using Model.Interfaces.Services;
using Model.Models;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> ProductsRepository = new List<Product> {
            new Product
            {
                Sku = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory
                {
                    Quantity = 15,
                    Warehouses = new List<Warehouse> {
                        new Warehouse { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                        new Warehouse { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }
                    }
                },
                IsMarketable = true
            }
        };

        /// <inheritdoc />
        public void Add(Product product)
        {
            var existentProduct = ProductsRepository.FirstOrDefault(_ => _.Sku == product.Sku);
		
            if (existentProduct != null) throw new Exception("Product already exists.");
		
            ProductsRepository.Add(product);
        }

        /// <inheritdoc />
        public Product Get(int id)
        {
            var product = ProductsRepository.FirstOrDefault(_ => _.Sku == id);
            if (product == null) return null;
           
            product.Inventory.Quantity = product.Inventory.Warehouses.Sum(_ => _.Quantity);
            product.IsMarketable = product.Inventory.Quantity > 0;
            
            return product;
        }

        /// <inheritdoc />
        public void Update(Product product)
        {
            var productToUpdate = ProductsRepository.FirstOrDefault(_ => _.Sku == product.Sku);
            if (productToUpdate == null) throw new Exception("Product does not exist.");

            var index = ProductsRepository.IndexOf(productToUpdate);
            ProductsRepository[index] = product;
        }

        public void Delete(int id)
        {
            var productToUpdate = ProductsRepository.FirstOrDefault(_ => _.Sku == id);
            if (productToUpdate == null) throw new Exception("Product does not exist.");

            var index = ProductsRepository.IndexOf(productToUpdate);
            ProductsRepository.RemoveAt(index);
        }
    }
}
