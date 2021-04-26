using DemoTest.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoTest.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected ContextRepository Context;
        protected DbSet<TEntity> InMemoryDb;

        public BaseRepository(ContextRepository context)
        {
            Context = context;
            InMemoryDb = Context.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity entidade)
        {
            var ret = InMemoryDb.Add(entidade);

            ret.State = EntityState.Added;

            return ret.Entity;
        }
        public virtual TEntity Atualizar(TEntity entidade)
        {
            var res = Context.Entry(entidade);

            InMemoryDb.Attach(entidade);

            res.State = EntityState.Modified;

            return entidade;
        }

        public IEnumerable<TEntity> RetornarQuando(Expression<Func<TEntity, bool>> expression)
        {
            return InMemoryDb.Where(expression);
        }

        public IEnumerable<TEntity> RetornarQuando(Expression<Func<TEntity, bool>> expression, bool semRastreio = false)
        {
            var res = InMemoryDb.Where(expression);

            if (res != null && semRastreio)
                foreach (var item in res)
                    Context.Entry(item).State = EntityState.Detached;

            return res;
        }

        public virtual TEntity RetornarPorID(long id, bool semRastreio = false)
        {
            var res = InMemoryDb.Find(id);

            if (res != null && semRastreio)
                Context.Entry(res).State = EntityState.Detached;

            return res;
        }

        public virtual void Deletar(long id)
        {
            var res = InMemoryDb.Find(id);

            InMemoryDb.Remove(res);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
