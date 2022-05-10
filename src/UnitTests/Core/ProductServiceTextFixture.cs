using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using SharedKernel.Interfaces;

namespace UnitTests.Core
{
    public abstract class ProductServiceTextFixture
    {
        protected IRepository<Product> _repository;
        protected IProductService _productService;
        protected AppDbContext _dbContext;

        private Repository<T> GetRepository<T>() where T : BaseEntity
        {
            _dbContext = new AppDbContext();
            return new Repository<T>(_dbContext);
        }

        protected IProductService GetProductService() {

            return new ProductService(this.GetRepository<Product>());
        }

    }
}
