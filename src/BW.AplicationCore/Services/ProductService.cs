using BW.AplicationCore.Entities;
using BW.AplicationCore.Interfaces.Repositories;
using BW.AplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BW.AplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product entity)
        {
            if (Get(entity.Sku) != null)
                throw new Exception($"Produto com sku {entity.Sku} ja existe!");
            _productRepository.Add(entity);
            
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }


        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }


        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
