using Core.Entities;
using Core.Interfaces;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;

        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public bool DeleteProduct(int sku)
        {
            var product = this.GetProduct(sku);
            if (product is null)
                throw new ArgumentException("This 'sku' not exists");

            this.repository.Delete(product);

            return true;
        }

        public Product GetProduct(int sku)
        {
            Func<Product, bool> predicate = x => sku.Equals(x.Sku);
            return this.repository.GetMany(predicate).FirstOrDefault();
        }

        public Product InsertProduct(Product product)
        {
            var produtoExistente = this.GetProduct(product.Sku);
            if (produtoExistente == null)
            {
                return this.repository.Add(product);
            }
            else
            {
                throw new InvalidOperationException("This 'sku' already exists.");
            }
        }

        public Product UpdateProduct(int sku, Product product)
        {
            var existingProduct = this.GetProduct(sku);
            if (existingProduct is null)
                throw new ArgumentException("This 'sku' not exists");

            this.repository.Update(existingProduct, product);

            return product;
            
        }
    }
}
