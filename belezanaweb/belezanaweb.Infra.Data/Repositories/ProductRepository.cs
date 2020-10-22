using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace belezanaweb.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(BelezanawebContext context)
            : base(context)
        {

        }

        public async Task<Product> FindBySkuAsync(int sku)
        {
            return await _context.Set<Product>().
                AsNoTracking().
                Include(p => p.Inventory).
                ThenInclude(i => i.Warehouses).
                FirstOrDefaultAsync(x => x.Sku == sku);
        }

        public async override Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().
                AsNoTracking()
                .Include(p => p.Inventory)
                .ThenInclude(i => i.Warehouses)
                .ToListAsync();
        }


    }
}
