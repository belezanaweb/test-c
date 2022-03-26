using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi
{
    public class ProductRepositoryMock : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepositoryMock()
        {
            _products = new List<Product>();
        }

        public Product? GetProduct(int sku)
        {
            return _products.FirstOrDefault(p => p.Sku == sku);
        }

        public List<Product> GetProducts()
        {
            return _products.ToList();
        }

        public void CreateProduct(Product product)
        {
            if (_products.Any(p => p.Sku == product.Sku))
            {
                throw new ValidationException($"A product with the informed SKU already exists in the repository.");
            }

            _products.Add(product);
        }

        public void UpdateProduct(int sku, Product product)
        {
            if (sku != product.Sku)
            {
                throw new ValidationException($"The SKU present in the request is different from the product SKU.");
            }

            _products.RemoveAll(p => p.Sku == sku);
            _products.Add(product);
        }

        public void DeleteProduct(int sku)
        {
            _products.RemoveAll(p => p.Sku == sku);
        }
    }
}