using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly Context Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(Context context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public long Add(T obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
            return obj.Id;
        }

        public T GetById(long id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public long Update(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
            return obj.Id;
        }

        public int Remove(long id)
        {
            DbSet.Remove(DbSet.Find(id));
            return Db.SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

