using System;
using System.Collections.Generic;
using TesteBoticario.Domain.Application;
using TesteBoticario.Domain.Dto;
using TesteBoticario.Domain.Repository;

namespace TesteBoticario.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            try
            {
                var productExists = _productRepository.Exists(product.Sku);

                if (productExists)
                    throw new ArgumentException($"Já existe um produto com o Sku informado.");

                _productRepository.Add(product);
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
                _productRepository.Update(product);
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
                return _productRepository.Delete(sku);
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
                var product = _productRepository.Get(sku);
                return product;
            }
            catch
            {
                throw;
            }
        }
    }
}
