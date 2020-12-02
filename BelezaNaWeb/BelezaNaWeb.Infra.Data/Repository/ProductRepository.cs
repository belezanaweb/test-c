using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>();
       
        public void CreateProduct(Product productParam)
        {
            try
            {
                products.Add(productParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductBySkuNumber(int sku)
        {
            try
            {
                if (products.Any(x => x.Sku == sku))
                    products.RemoveAll(x => x.Sku == sku);
                else
                    throw new ArgumentException($"Produto não encontrado!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetBySkuNumber(int sku)
        {
            try
            {
                return products.FirstOrDefault(x => x.Sku == sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Product productParam)
        {
            try
            {
                if (products.Any(x => x.Sku == productParam.Sku))
                {
                    var index = products.FindIndex(x => x.Sku == productParam.Sku);
                    products[index] = productParam;
                }
                else
                {
                    throw new ArgumentException($"Produto não encontrado!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}