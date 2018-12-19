using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using testc.Model.Base;
using testc.Model.Context;

namespace testc.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long sku)
        {
            var result = dataset.SingleOrDefault(u => u.Sku.Equals(sku));

            try
            {
                if (result != null) dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? sku)
        {
            return dataset.Any(u => u.Sku.Equals(sku));
        }

        public List<T> GetAll()
        {
            return dataset.ToList();
        }

        public T GetBySku(long sku)
        {
            return dataset.SingleOrDefault(p => p.Sku.Equals(sku));
        }

        public T Update(T item)
        {
            if (!Exists(item.Sku)) return null;
            var result = dataset.SingleOrDefault(i => i.Sku.Equals(item.Sku));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
