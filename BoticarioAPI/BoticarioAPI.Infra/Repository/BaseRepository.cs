using BoticarioAPI.Domain.Interfaces.Repository;
using BoticarioAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BoticarioAPI.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
         where TEntity : class
    {
        protected readonly BoticarioContext db;
        protected readonly DbSet<TEntity> dbSet;
        public BaseRepository(BoticarioContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Add(List<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Delete(object id)
        {
            var entityToRemove = dbSet.Find(id);
            if (entityToRemove != null)
                Remove(entityToRemove);
        }

        public virtual void Remove(TEntity entityToRemove)
        {
            if (db.Entry(entityToRemove).State == EntityState.Detached)
                dbSet.Attach(entityToRemove);
            dbSet.Remove(entityToRemove);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void UpdateRange(List<TEntity> listEntityToUpdate)
        {
            foreach (var entity in listEntityToUpdate)
            {
                dbSet.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
