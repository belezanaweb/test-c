using System.Collections.Generic;

using TestC.ExceptionHandler;
using TestC.Models;
using TestC.Repositories;

namespace TestC.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _repository;
        public ProductService(IBaseRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Insert(Product product)
        {
            var productAux = _repository.GetByID(product.sku);

            if (productAux != null)
                throw new HttpResponseException(string.Format("Já existe um produto com esse sku ({0}).", product.sku));

            return _repository.Insert(product);
        } 

        public Product Update(Product product)
        {
            var productAux = _repository.GetByID(product.sku);

            if (productAux == null)
                throw new HttpResponseException(string.Format("Não foi encontrado nenhum produto com o sku {0}.", product.sku), 404);

            return _repository.Update(product);
        }

        public void Delete(int sku)
        {
            var productAux = _repository.GetByID(sku);

            if (productAux == null)
                throw new HttpResponseException(string.Format("Não foi encontrado nenhum produto com o sku {0}.", sku), 404);

            _repository.Delete(sku);
        }

        public Product GetByID(int sku)
        {
            return _repository.GetByID(sku);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

    }
}