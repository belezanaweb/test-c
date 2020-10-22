using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace belezanaweb.Application.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public async Task DeleteAsync(TEntity obj)
        {
            await _repository.DeleteAsync(obj);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }
    }
}
