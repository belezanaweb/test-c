using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        public BaseRepository(ProductDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbContext Context { get; private set; }

        protected IQueryable<T> Query => Context.Set<T>();

        public virtual async Task AddAsync(T entity)
        {
            Context.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            Context.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Context.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}
