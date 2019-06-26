using BNW.App.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BNW.App
{
    public class ProductApplication : ApplicationBase<Product>, IProductApplication
    {
        IProductRepository _repo;
        public ProductApplication(IProductRepository repository) : base(repository)
        {
            _repo = repository;
        }

        public async new Task<Product> GetById(int id)
        {
            var product = await base.GetById(id);
            if (product != null)
            {
                product.inventory.quantity = product.inventory.warehouses.Sum(x => x.quantity);
                product.isMarketable = product.inventory.quantity > 0;
                return product;
            }

            throw new ArgumentException("SKU já existente");
        }
    }
}
