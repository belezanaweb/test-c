using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace belezanaweb.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly BelezanawebContext _context;

        public RepositoryBase(BelezanawebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
        }

        public async Task DeleteAsync(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
