using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Models;
using BelezaNaWeb.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BelezaNaWeb.Infrastructure.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BelezaNaWebContext belezaNaWebContext) : base(belezaNaWebContext)
        {
        }

        public Product GetBySku(int sku)
        {
            return DbSet.Include(p => p.Inventory).ThenInclude(i => i.Warehouse)
                .FirstOrDefault(p => p.Sku == sku);
        }
    }
}
