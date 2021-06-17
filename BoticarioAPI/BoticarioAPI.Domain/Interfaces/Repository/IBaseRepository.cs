using System.Collections.Generic;

namespace BoticarioAPI.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);

        void Add(List<TEntity> entities);

        void Delete(object id);

        void Remove(TEntity entityToRemove);

        void Update(TEntity entityToUpdate);

        void UpdateRange(List<TEntity> listEntityToUpdate);
    }
}
