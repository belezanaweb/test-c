using GrupoBoticario.Domain.Entity.Base;
using GrupoBoticario.Domain.IRepositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoBoticario.DataAccess.Repositories.Generic
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : ObjetoBase
    {
        protected DbSet<TEntity> DbSet;
        protected Context DbContext;
        public RepositoryBase(Context dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        #region CREATE ENTITY
        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Attach(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            var result = DbSet.Attach(entity).Entity;

            DbContext.SaveChanges();

            return Task.FromResult(result);
        }

        public virtual void AddRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.AttachRange(entityCollection);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entityCollection)
        {
            DbSet.AttachRange(entityCollection);

            DbContext.SaveChangesAsync();

            return Task.CompletedTask;
        }

        #endregion

        #region EXISTS ENTITY
        public virtual bool Any()
        {
            return DbSet.Any();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual Task<bool> AnyAsync()
        {
            return DbSet.AnyAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AnyAsync(predicate);
        }

        #endregion

        #region UPDATE ENTITY
        public virtual void Update(TEntity entity, bool updateRelated = false)
        {
            if (updateRelated)
                DbSet.Update(entity);
            else
                DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task UpdateAsync(TEntity entity, bool updateRelated = false)
        {
            if (updateRelated)
                DbSet.Update(entity);
            else
                DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entityCollection, bool updateRelated = false)
        {
            if (updateRelated)
                DbSet.UpdateRange(entityCollection);
            else
                foreach (var entity in entityCollection)
                    DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entityCollection, bool updateRelated = false)
        {
            if (updateRelated)
                DbSet.UpdateRange(entityCollection);
            else
                foreach (var entity in entityCollection)
                    DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.SaveChangesAsync();

            return Task.CompletedTask;
        }
        #endregion

        #region DELETE ENTITY
        public virtual void Delete(TEntity entity, bool deleteRelated = false)
        {
            if (deleteRelated)
                DbSet.Remove(entity);
            else
                DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public Task DeleteAsync(TEntity entity, bool deleteRelated = false)
        {
            if (deleteRelated)
                DbSet.Remove(entity);
            else
                DbContext.Entry(entity).State = EntityState.Deleted;

            DbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public void DeleteRange(IEnumerable<TEntity> entities, bool deleteRelated = false)
        {
            if (deleteRelated)
                DbSet.RemoveRange(entities);
            else
                foreach (var entity in entities)
                    DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool deleteRelated = false)
        {
            if (deleteRelated)
                DbSet.RemoveRange(entities);
            else
                foreach (var entity in entities)
                    DbContext.Entry(entity).State = EntityState.Deleted;

            return Task.CompletedTask;
        }

        #endregion

        public async Task<long> ObterProximoIdAsync()
        {
            //bool encontrouCodigoDisponivel = false;
            //long menorCodigo = 0;

            //var quantidadeRegistro = await DbSet.CountAsync();

            //if (quantidadeRegistro <= 0)
            //    return await Task.FromResult(1);

            //while (encontrouCodigoDisponivel is false)
            //{
            //    if (menorCodigo <= 0)
            //    {
            //        menorCodigo = await DbSet.
            //               MinAsync(x => x.Sku) + 1;
            //    }

            //    var existeCodigo = await DbSet.AnyAsync(x => x.Sku == menorCodigo);

            //    if (existeCodigo is true)
            //    {
            //        menorCodigo += 1;
            //        encontrouCodigoDisponivel = false;
            //    }
            //    else
            //    {
            //        encontrouCodigoDisponivel = true;
            //        return await Task.FromResult(menorCodigo);
            //    }
            //}

            return await Task.FromResult(1);
        }

        public Task CommittAsync() => DbContext.SaveChangesAsync();

        public void Committ() => DbContext.SaveChanges();
    }
}
