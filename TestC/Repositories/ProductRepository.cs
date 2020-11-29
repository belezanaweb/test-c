using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using TestC.Models;

namespace TestC.Repositories
{
    [ExcludeFromCodeCoverageAttribute]
    public class ProductRepository: IBaseRepository<Product>
    {
        private List<Product> productList = new List<Product>();

        public Product Insert(Product model)
        {
            productList.Add(model);
            return model;
        }

        public Product Update(Product model)
        {
            int index = productList.FindIndex(p => p.sku == model.sku);
            
            if (index >= 0) {
                productList[index] = model;
                return model;
            }

            return null;
        }

        public void Delete(int sku)
        {
            int index = productList.FindIndex(p => p.sku == sku);

            if (index >= 0)
                productList.RemoveAt(index);
        }

        public Product GetByID(int sku)
        {
            return productList.FirstOrDefault(p => p.sku == sku);
        }

        public List<Product> GetAll()
        {
            return productList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}