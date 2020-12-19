using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.Test.Application.Interface
{
    public interface IRepository<T>
    {
        Task<T> add(T entity);
        Task update(T entity);
        Task remove(T entity);
        Task<IEnumerable<T>> getAll();
        Task<T> getBy(Func<T, bool> predicate);
        Task<IEnumerable<T>> AddInclude(T entity, string include);
    }
}