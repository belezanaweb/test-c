using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        void Add(T obj);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
