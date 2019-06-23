using BNW.App.Interfaces;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BNW.App
{
    public class ApplicationBase<T> : IApplicationBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repo;

        public ApplicationBase(IRepositoryBase<T> repository)
        {
            _repo = repository;
        }

        public void Add(T obj)
        {
            _repo.Add(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public void Remove(T obj)
        {
            _repo.Remove(obj);
        }

        public void Update(T obj)
        {
            _repo.Update(obj);
        }
    }
}
