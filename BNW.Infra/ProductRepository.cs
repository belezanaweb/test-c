using Domain.Entities;
using Domain.Interfaces;

namespace BNW.Infra
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
    }
}
