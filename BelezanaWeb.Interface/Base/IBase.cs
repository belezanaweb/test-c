using BelezanaWeb.Model;

namespace BelezanaWeb.Interface.Repository.Base
{
    public interface IBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        Result<TEntity> SaveSync(TEntity entity);
        void Dispose();
    }
}
