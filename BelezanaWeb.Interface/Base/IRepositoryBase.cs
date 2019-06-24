using BelezanaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BelezanaWeb.Interface.Repository.Base
{
    //public interface IRepositoryBase<T> : IBase<T> where T : class
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(long? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> expression);

        void Save(T entity);
        void Remove(T entity);

        //Result<T> SaveSync(T entity);
        //void Dispose();
    }
}
