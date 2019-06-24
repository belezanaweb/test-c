using System;
using System.Collections.Generic;
using System.Text;

namespace BW.AplicationCore.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);

    }
}
