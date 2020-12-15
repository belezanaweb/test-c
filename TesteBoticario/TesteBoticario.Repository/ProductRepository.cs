using System;
using System.Collections.Generic;
using System.Linq;
using TesteBoticario.Domain.Dto;
using TesteBoticario.Domain.Repository;

namespace TesteBoticario.Repository.Memory
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> productList = new List<Product>();

        public void Add(Product product)
        {
            try
            {
                productList.Add(product);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                if (Exists(product.Sku))
                {
                    var index = productList.FindIndex(pl => pl.Sku == product.Sku);
                    productList[index] = product;
                }
                else
                    throw new Exception($"Produto {product.Sku} não encontrado!");
            }
            catch
            {
                throw;
            }
        }

        public bool Exists(int sku)
        {
            try
            {
                return productList.Exists(pl => pl.Sku == sku);
            }
            catch
            {
                throw;
            }
        }

        public Product Get(int sku)
        {
            try
            {
                return productList.FirstOrDefault(x => x.Sku == sku);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int sku)
        {
            try
            {
                return productList.RemoveAll(pl => pl.Sku == sku) > 0;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return productList;
            }
            catch
            {
                throw;
            }
        }
    }
}
