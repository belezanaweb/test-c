namespace Boticario.Backend.Data.Connection
{
    public interface IConnectionPool
    {
        IConnection Pop();
        void Push(IConnection connection);
    }
}
