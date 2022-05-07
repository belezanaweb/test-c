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
            if (!(_products?.Any() ?? false))
            {
                validateQuantity(product.inventory.warehouses);
                _products = new List<Product> { product };
            }
            else
            {
                validateQuantity(product.inventory.warehouses);

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
            
            validateQuantity(product.inventory.warehouses);

            int productIndex = _products.FindIndex(c => c.sku == sku);

            if (productIndex < 0)
            {
                throw new DomainException("Sku não existe na base!");
            }

            product.sku = sku;

            _products[productIndex] = product;
        }

        private static void validateQuantity(List<Warehouse> warehouses)
        {
            if ((warehouses?.Any() ?? false) && warehouses.Any(c => c.quantity < 0))
            {
                throw new DomainException("Valor da quantidade de um ou mais dos estoques está negativo!");
            }
        }
    }
}
