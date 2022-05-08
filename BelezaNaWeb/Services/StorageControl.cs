using System.Collections.Generic;
using BelezaNaWeb.Entities;
using System.Linq;
using System;
using BelezaNaWeb.Exceptions;

namespace BelezaNaWeb.Services
{
    public class StorageControl
    {
        private static List<Product> _products;

        public static void AddProduct(Product product)
        {
            validateProduct(product);
            if (!(_products?.Any() ?? false))
            {
                _products = new List<Product> { product };
            }
            else
            {

                Product productValidate = _products.Find(c => c.sku == product.sku);
                if (productValidate != null)
                {
                    throw new DomainException("Produto com este sku já existe na base!");
                }
                _products.Add(product);
            }
        }

        public static Product GetProduct(long sku)
        {
            if (!(_products?.Any() ?? false))
            {
                throw new DomainException("Sku não existe na base!");
            }
            Product productValidate = _products.Find(c => c.sku == sku);

            if (productValidate == null)
            {
                throw new DomainException("Sku não existe na base!");
            }

            return productValidate;
        }

        public static void UpdateProduct(long sku, Product product)
        {
            if (!(_products?.Any() ?? false))
            {
                throw new DomainException("Sku não existe na base!");
            }

            product.sku = sku;

            validateProduct(product);

            int productIndex = _products.FindIndex(c => c.sku == sku);

            if (productIndex < 0)
            {
                throw new DomainException("Sku não existe na base!");
            }

            _products[productIndex] = product;
        }

        private static void validateProduct(Product product)
        {
            if (product.sku <= 0)
            {
                throw new DomainException("Sku do produto não pode ser 0, vazio ou negativo!");
            }
            if ((product.inventory.warehouses?.Any() ?? false) && product.inventory.warehouses.Any(c => c.quantity < 0))
            {
                throw new DomainException("Valor da quantidade de um ou mais dos estoques está negativo!");
            }
        }
    }
}
