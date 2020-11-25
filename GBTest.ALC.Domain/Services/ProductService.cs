using System.Collections.Generic;
using GBTest.ALC.Domain.Entities;
using GBTest.ALC.Domain.Interfaces;

namespace GBTest.ALC.Domain.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(string id)
        {
            return _productRepository.Get(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Add(Product obj)
        {
            _productRepository.Add(obj);
        }

        public void Update(Product obj)
        {
            _productRepository.Update(obj);
        }

        public void Remove(Product obj)
        {
            _productRepository.Remove(obj);
        }

        public void Dispose()
        {
            _productRepository = null;
        }
    }
}
