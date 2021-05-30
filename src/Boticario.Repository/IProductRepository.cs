using Boticario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boticario.Repository
{
    public interface IProductsRepository
    {

            IQueryable<Products> GetCollectionAsync();
            Task<List<Products>> FindAsync(Expression<Func<Products, bool>> condition= null, int limit= 0, int page = 0);
            Task<Products> FindOneAsync(Func<Products, bool> condition = null);

            Task<Products> FindByIdAsync(Guid id);

            Task<Products> CreateAsync(Products product);

            Task<Products> UpdateAsync(Products product);

            Task DeleteByIdAsync(Guid id);
        
    }
}
