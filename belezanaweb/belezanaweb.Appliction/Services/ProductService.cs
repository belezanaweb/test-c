using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace belezanaweb.Application.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<Product> FindBySkuAsync(int sku)
        {
            return await _repository.FindBySkuAsync(sku);
        }

    }
}
