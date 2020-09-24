using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using BelezaNaWeb.Domain.Interfaces.Entities;

namespace BelezaNaWeb.Framework.Data.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region IGenericRepository Members

        Task<TEntity> Get(object id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAll(
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        );

        Task<TEntity> Find(
              Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        );

        Task<IEnumerable<TEntity>> FindAll(
              Expression<Func<TEntity, bool>> predicate
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        );

        Task<IPagedListEntity<TEntity>> PagedList(
              int pageIndex
            , int pageSize
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool disableTracking = true
        );

        Task Create(TEntity entity);

        Task Update(object id, TEntity entity);

        Task Delete(object id);

        void Delete(TEntity entity);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        Task<int> Count(Expression<Func<TEntity, bool>> predicate = null);

        #endregion
    }
}
