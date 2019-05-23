using BlzWeb.Domain.StoreContext.Entities;
using BlzWeb.Domain.StoreContext.Repositories;
using BlzWeb.Domain.StoreContext.Services;

namespace BlzWeb.Infra.StoreContext.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public Product Get(int sku)
        {
            return _repository.Get(sku);
        }
    }
}
