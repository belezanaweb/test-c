namespace webapi.domain.Gateways.Abstractions.Respository
{
    public interface IRepositoryGateway<TEntity, TKey>
    {
        Task<TEntity> Get(TKey key);
        Task Update(TEntity entity);
        Task Insert(TEntity entity);
        Task Delete(TKey key);
    }
}