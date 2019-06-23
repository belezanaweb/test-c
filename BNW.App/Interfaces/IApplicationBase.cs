using System.Collections.Generic;
using System.Threading.Tasks;

namespace BNW.App.Interfaces
{
    public interface IApplicationBase<T> where T : class
    {
        void Add(T obj);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
