using BelezaNaWeb.CrossCutting;
using BelezaNaWeb.Domain;
using System;
using System.Collections.Generic;

namespace BelezaNaWeb.Data
{
    public class ProductData
    {
        public static List<Product> Products { get; set; } = new List<Product>();

        public void Add(Product product)
        {
            if (Products.Exists(p => p.Sku == product.Sku))
                throw new AlreadyExistsException("Produto já foi cadastrado.");

            Products.Add(product);
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public Product GetById(int sku)
        {
            var indexProductFound = GetIndexProduct(sku);

            return Products[indexProductFound];
        }

        public void Update(Product product)
        {
            var indexProductFound = GetIndexProduct(product.Sku);

            Products[indexProductFound] = product;
        }

        public void Delete(int sku)
        {
            var productFound = Products.Find(p => p.Sku == sku);
            if (productFound != null)
                Products.Remove(productFound);
        }

        private int GetIndexProduct(int sku)
        {
            var indexProductFound = Products.FindIndex(p => p.Sku == sku);

            if (indexProductFound == -1)
                throw new NotFoundException("Produto não encontrado.");

            return indexProductFound;
        }
    }
}
