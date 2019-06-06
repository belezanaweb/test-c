using Domain.Entities;
using System;
using System.Linq;

namespace Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        long Add(T obj);        T GetById(long id);        IQueryable<T> GetAll();        long Update(T obj);        int Remove(long id);        int SaveChanges();
    }
}
