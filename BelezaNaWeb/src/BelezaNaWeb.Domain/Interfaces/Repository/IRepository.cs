using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BelezaNaWeb.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        TEntity ObterPorIdNoTracking(Guid id);
        IEnumerable<TEntity> ObterTodos(int? pageSize, int? page);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        TEntity RemoverObj(TEntity obj);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
