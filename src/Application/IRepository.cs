
using Core.Entities;
using System;
using System.Collections.Generic;

namespace SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> expression);
        T GetBy(Predicate<T> expression);
        T Add(T entity);
        void Update(T oldEntity, T newEntity);
        void Delete(T entity);
    }
}
