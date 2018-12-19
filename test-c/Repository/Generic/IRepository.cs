using System.Collections.Generic;
using testc.Model.Base;

namespace testc.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        List<T> GetAll();
        T GetBySku(long sku);
        void Delete(long sku);
        bool Exists(long? sku);
    }
}
