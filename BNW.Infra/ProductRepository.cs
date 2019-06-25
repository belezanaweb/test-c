using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BNW.Infra
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public new async Task<Product> GetById(int id)
        {
            var all = await GetAll();
            return all == null || all.Count()==0 ? null : all.First(x => x.sku == id);
        }
    }
}
