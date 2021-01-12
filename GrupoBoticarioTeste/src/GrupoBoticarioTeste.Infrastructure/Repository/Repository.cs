using GrupoBoticarioTeste.Business.Interfaces.Repositories;
using GrupoBoticarioTeste.Infrastructure.Context;

namespace GrupoBoticarioTeste.Infrastructure.Repository
{    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _dbContext;

        protected Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Adicionar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();            
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
