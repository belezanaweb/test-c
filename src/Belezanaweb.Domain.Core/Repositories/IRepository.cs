using Belezanaweb.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Belezanaweb.Domain.Core.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetList(int skip, int take);
        void Insert(T entity);
        T Get(long id);
        void Delete(T entity);
        void Update(T entity);
    }
}
