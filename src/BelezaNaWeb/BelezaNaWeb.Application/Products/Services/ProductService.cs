using System.Collections.Generic;
using BelezaNaWeb.Application.Products.Interfaces;
using BelezaNaWeb.Core.Products.Exceptions;
using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Domain.Products.Interfaces;

namespace BelezaNaWeb.Application.Products.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository Repository;

        public ProductService(IProductRepository rep)
        {
            Repository = rep;
        }

        public void Delete(long sku)
        {
            Repository.Delete(sku);
        }

        public Product Get(long sku)
        {
            return Repository.Get(sku);
        }

        public IEnumerable<Product> Get()
        {
            return Repository.Get();
        }

        public void Save(Product product)
        {
            var existingProduct = Repository.Get(product.Sku);
            if (existingProduct != null)
                throw new ExistingSkuException();

            Repository.Save(product);
        }

        public void Update(Product product)
        {
            Repository.Save(product);
        }
    }
}
