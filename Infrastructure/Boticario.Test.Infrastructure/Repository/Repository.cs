using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boticario.Test.Application.Entity;
using Boticario.Test.Application.Interface;
using Boticario.Test.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Boticario.Test.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SkuContext _context;

        public Repository(SkuContext context)
        {
            _context = context;
        }

        public async Task<T> add(T entity)
        {
            await BeginTransactionAsync();

            try
            {
                var newEntity = await _context.AddAsync<T>(entity);
                await CommitAsync();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                await RollbackAsync();
                throw ex;
            }
            
            
        }

        public async Task<IEnumerable<T>> getAll()
        {
            return await Task.FromResult(_context.Set<T>().AsQueryable());
        }

        public async Task<T> getBy(Func<T, bool> predicate)
        {
            return await Task.FromResult(_context.Set<T>().FirstOrDefault(predicate));
        }

        public async Task<IEnumerable<T>> AddInclude(T entity, string include)
        {
            return await Task.FromResult(_context.Set<T>()
                .Where(x => x.Equals(entity))
                .Include(include));
        }

        public async Task remove(T entity)
        {
            try
            {
                await BeginTransactionAsync();

                _context.Remove<T>(entity);
                await CommitAsync();
            }
            catch (Exception ex)
            {
                await RollbackAsync();
                throw ex;
            }
        }

        public async Task update(T entity)
        {
            try
            {
                await BeginTransactionAsync();

                _context.Update<T>(entity);
                await CommitAsync();
            }
            catch (Exception ex)
            {
                await RollbackAsync();
                throw ex;
            }
            
        }

        private async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        private async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            _context.Database.CommitTransaction();
        }

        private async Task RollbackAsync()
        {
            await Task.Run(() => _context.Database.RollbackTransaction());
        }
    }
}