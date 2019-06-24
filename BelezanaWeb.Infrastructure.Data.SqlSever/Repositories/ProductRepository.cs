using BelezanaWeb.Interface.Repository;
using BelezanaWeb.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BelezanaWeb.Infrastructure.Data.SqlSever.Repositories.PoC
{
    public class ProductRepository : BelezanaWebRepositoryBase<Product>, IProductRepository
    {
        public List<Product> GetWithWarehouses()
        {
            var query = databaseContext.Product.Where(
                x => x.Active)
                .Include(x => x.Warehouses);

            return query.ToList();
        }

        public List<Product> GetWithWarehouses(Expression<Func<Product, bool>> expression)
        {
            var query = databaseContext.Product.Where(expression)
                .Include(x => x.Warehouses);

            return query.ToList();
        }
    }
}
