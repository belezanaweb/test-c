using System;
using System.Collections.Generic;
using testc.Model;
using testc.Repository.Generic;

namespace testc.Business
{
    public class ProductBusinessImpl : IProductBusiness
    {
        private IRepository<Product> _repository;

        public ProductBusinessImpl(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public void Delete(long sku)
        {
            _repository.Delete(sku);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetBySku(long sku)
        {
            return _repository.GetBySku(sku);
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
    }
}
