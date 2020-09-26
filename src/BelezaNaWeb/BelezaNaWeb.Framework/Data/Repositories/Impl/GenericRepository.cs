using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Domain.Entities.Impl;
using Microsoft.EntityFrameworkCore.Query;
using BelezaNaWeb.Framework.Data.Contexts;

namespace BelezaNaWeb.Framework.Data.Repositories.Impl
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Protected Read-Only Fields

        protected readonly ILogger _logger;
        protected readonly ApiContext _dbContext;

        #endregion

        #region Constructors

        public GenericRepository(ILogger logger, ApiContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion

        #region IGenericRepository Members

        public virtual async Task<TEntity> Get(object id)
            => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAll()
            => await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAll(
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        )
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> Find(
              Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAll(
              Expression<Func<TEntity, bool>> predicate
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        )
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedListEntity<TEntity>> PagedList(
              int pageIndex
            , int pageSize
            , Expression<Func<TEntity, bool>> predicate
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        )
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            var output = new PagedListEntity<TEntity>(pageIndex, pageSize)
            {
                Total = await query.CountAsync()
            };

            if (orderBy != null)
                output.Collection = await orderBy(query)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .ToListAsync();
            else
                output.Collection = await query
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .ToListAsync();

            return output;
        }

        public virtual async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task Update(object id, TEntity entity)
        {
            var existing = await Get(id);

            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(entity);                
            }
        }

        public virtual async Task Delete(object id)
        {
            var entity = await Get(id);
            if (entity != null) _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
            => await _dbContext.Set<TEntity>().AnyAsync(predicate);

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                var query = _dbContext.Set<TEntity>().AsQueryable();
                if (predicate != null) query = query.Where(predicate);

                return await query.CountAsync();
            }
            catch (InvalidOperationException) { return await Task.FromResult(0); }
        }

        #endregion
    }
}
