using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.Interfaces.Repository;
using BoticarioAPI.Infra.Context;
using System.Linq;

namespace BoticarioAPI.Infra.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly BoticarioContext _context;
        public ProductRepository(BoticarioContext context) : base(context)
        {
            _context = context;
        }

        public Product GetBySku(int sku)
        {
           return _context.Products.Where(product => product.Sku == sku).FirstOrDefault();
        }
    }
}
