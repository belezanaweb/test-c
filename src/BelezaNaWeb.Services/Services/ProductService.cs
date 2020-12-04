using BelezaNaWeb.Data.Models;
using BelezaNaWeb.Data.Repositories.Interfaces;
using BelezaNaWeb.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BelezaNaWeb.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAll() => _productRepository.Select();

        public Product Find(int sku) => _productRepository.Select(sku);

        public void Update(int sku, Product newProduct)
        {
            var product = _productRepository.Select(sku);
            if (product is null) throw new Exception($"O produto de SKU {sku} não foi encontrado.");

            product.Name = newProduct.Name;
            product.Inventory = newProduct.Inventory;

            _productRepository.Update(product);
        }
        
        public void Delete(int sku)
        {
            var product = _productRepository.Select(sku);
            if (product is null) throw new Exception($"O produto de SKU {sku} não foi encontrado.");

            _productRepository.Delete(sku);
        }

        public void Insert(Product newProduct)
        {
            var product = _productRepository.Select(newProduct.Sku);
            if (product != null) throw new Exception($"O produto de SKU {product.Sku} já existe na base.");

            _productRepository.Insert(newProduct);
        }



    }
}
