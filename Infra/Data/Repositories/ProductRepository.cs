using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context)
            : base(context) { }
        
    }
}
