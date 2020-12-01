using Domain.Exceptions;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> _products;

        public ProductRepository()
        {
            _products = new List<ProductModel>();
        }

        public bool Create(ProductModel product)
        {
            if (_products.Any(x => x.Sku == product.Sku))
            {
                throw new ProductException("Sku already exists in the repository");
            }
            _products.Add(product);

            return true;
        }

        public bool Delete(long sku)
        {
            var product = _products.FirstOrDefault(x => x.Sku == sku);

            if (product == null)
            {
                throw new ProductException("Product not found");
            }

            _products.Remove(product);

            return true;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            _products.ForEach(product =>
            {
                product.Build();
            });

            return _products;
        }

        public ProductModel GetBySku(long sku)
        {
            var productFound = _products.FirstOrDefault(x => x.Sku == sku);

            if(productFound == null)
            {
                throw new ProductException("Product not found");
            }

            return productFound.Build();
        }

        public bool Update(long sku, ProductModel product)
        {
            var productFound = _products.FirstOrDefault(x => x.Sku == sku);

            if (productFound == null)
            {
                throw new ProductException("Product not found");
            }

            _products[_products.IndexOf(productFound)] = product;

            return true;
        }
    }
}
