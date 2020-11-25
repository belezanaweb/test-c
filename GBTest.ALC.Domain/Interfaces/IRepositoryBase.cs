using System;
using System.Collections.Generic;

namespace GBTest.ALC.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity Get(string id);
        List<TEntity> GetAll();
    }
}
