using System;

namespace GrupoBoticarioTeste.Business.Interfaces.Repositories
{    
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);        
        void Remover(TEntity entity);
    }
}
