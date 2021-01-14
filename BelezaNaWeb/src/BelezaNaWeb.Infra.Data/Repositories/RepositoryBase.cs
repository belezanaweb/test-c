using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Emprestae.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var ret = DbSet.Add(obj);
            return ret.Entity;
        }

        public virtual TEntity ObterPorIdNoTracking(Guid id)
        {
            var entity = ObterPorId(id);

            if (entity != null)
                Db.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos(int? take, int? skip)
        {
            if (take != null && skip != null)
                return DbSet.Take(take.Value).Skip(skip.Value).ToList();
            else
                return DbSet.ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);

            DbSet.Attach(obj);

            entry.State = EntityState.Modified;
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var obj = DbSet.Find(id);

            DbSet.Remove(obj ?? throw new InvalidOperationException());
        }

        public TEntity RemoverObj(TEntity obj)
        {
            DbSet.Remove(obj);

            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual int ExecuteNonQuery(string sql)
        {
            var cmd = Db.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;

            return cmd.ExecuteNonQuery();
        }

        public virtual object ExecuteReader(string sql)
        {
            var cmd = Db.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;

            return cmd.ExecuteReader();
        }
    }
}
