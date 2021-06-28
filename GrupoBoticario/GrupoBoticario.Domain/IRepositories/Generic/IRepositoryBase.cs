using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.Domain.IRepositories.Generic
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entityCollection);

        Task AddRangeAsync(IEnumerable<TEntity> entityCollection);

        bool Any();

        bool Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity, bool updateRelated = false);

        Task UpdateAsync(TEntity entity, bool updateRelated = false);

        void UpdateRange(IEnumerable<TEntity> entityCollection, bool updateRelated = false);

        Task UpdateRangeAsync(IEnumerable<TEntity> entityCollection, bool updateRelated = false);

        void Delete(TEntity entity, bool deleteRelated = false);

        void DeleteRange(IEnumerable<TEntity> entities, bool deleteRelated = false);

        Task DeleteAsync(TEntity entity, bool deleteRelated = false);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool deleteRelated = false);


        Task<long> ObterProximoIdAsync();

        Task CommittAsync();

        void Committ();
    }
}
