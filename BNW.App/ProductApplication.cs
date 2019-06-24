using BNW.App.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace BNW.App
{
    public class ProductApplication : ApplicationBase<Product>, IProductApplication
    {
        IProductRepository _repo;
        public ProductApplication(IProductRepository repository) : base(repository)
        {
            _repo = repository;
        }
    }
}
