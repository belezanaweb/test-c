using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BNW.Infra
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected dynamic _db;  //dbcontext
        public RepositoryBase()
        {
            //_db = db;
            _db = null;
        }

        public async void Add(T obj)
        {
            return;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return null;
        }

        public async Task<T> GetById(int id)
        {
            return null;
        }

        public async void Remove(T obj)
        {
            return;
        }

        public async void Update(T obj)
        {
            return;
        }
    }
}
