using BelezaNaWeb.Data.Context;
using BelezaNaWeb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BelezaNaWebContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(BelezaNaWebContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await Db.SaveChangesAsync();
        }

        public async Task Deletar(long id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await  DbSet.FindAsync(id);
        }

        public  void  Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Update(entity);
        }
    }
}
