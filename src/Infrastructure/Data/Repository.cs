using Core.Entities;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.context.CreateDatabase<T>();
        }

        public T Add(T entity)
        {
            var existingEntity = this.GetMany(x => entity.Equals(x)).Any();

            if (existingEntity)
                throw new InvalidOperationException("This entity already exists");            

            this.context.Set<T>().Add(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            var existingEntity = this.GetMany(x => entity.Equals(x)).Any();

            if (!existingEntity)
                throw new InvalidOperationException("This entity doesn't exists");

            this.context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public IEnumerable<T> GetMany(Func<T, bool> expression)
        {
           return this.context.Set<T>().Where(expression);
        }

        public T GetBy(Predicate<T> expression)
        {           
            var ret = this.context.Set<T>().Find(expression);
            return ret;
        }

        public void Update(T oldEntity, T entity)
        {
            this.context.Set<T>().Remove(oldEntity);
            this.context.Set<T>().Add(entity);            
        }

       
    }
}
