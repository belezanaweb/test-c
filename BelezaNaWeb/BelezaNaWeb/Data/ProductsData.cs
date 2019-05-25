using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BelezaNaWeb.Models;

namespace BelezaNaWeb.Data
{
    public class ProductsData
    {
        private static List<ProductModel> listProducts = new List<ProductModel>();

        public void Add(ProductModel product)
        {
            if (listProducts.Any(n => n.sku == product.sku))
                throw new Exception("Produto já existe no banco.");

            listProducts.Add(product);
        }

        public List<ProductModel> GetProducts()
        {
            return listProducts;
        }

        public ProductModel GetProductBySKU(int sku)
        {
            ProductModel product = listProducts.Find(n => n.sku == sku);

            if (product == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            return product;
        }

        public void ModifyProduct(int sku, ProductModel product)
        {
            if (!listProducts.Any(n => n.sku == sku))
                throw new Exception("Produto não encontrado.");

            listProducts.Where(n => n.sku == sku)
                .Select(s =>
                {
                    s.name = product.name;
                    s.inventory = product.inventory;

                    return s;
                }).ToList();
        }

        public void RemoveProduct(int sku)
        {
            ProductModel product = listProducts.Find(n => n.sku == sku);

            if (product != null)
                listProducts.Remove(product);
            else
                throw new Exception("Produto não encontrado");
        }
    }
}